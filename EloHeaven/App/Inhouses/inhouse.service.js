(function() {
    
    angular
        .module("eloHeaven.inhouses")
        .factory("inhouseService", inhouseService);
        
    function inhouseService($http, $q, $timeout) {
        var blueTeam = [];
        var redTeam = [];
        var maxNumberOfPlayersPerTeam = 5;

        activate();

        function activate() {
            for (var i = 0; i < maxNumberOfPlayersPerTeam; i++) {
                blueTeam.push({
                    name: "",
                    status: "empty"
                });

                redTeam.push({
                    name: "",
                    status: "empty"
                });
            }
        }

        return {
            getTeams: getTeams,
            addPlayer: addPlayer,
            removePlayer: removePlayer,
            balanceTeams: balanceTeams,
            swapPlayers: swapPlayers
        };
        
        function getTeams() {
            return {
                blueTeam: blueTeam,
                redTeam: redTeam
            };
        }

        function addPlayer(playerName) {
            var numDupes = 0;

            for (var i = 0; i < maxNumberOfPlayersPerTeam; i++) {
                if (blueTeam[i].name.toLowerCase().replace(" ", "") === playerName.toLowerCase().replace(" ", "") ||
                    redTeam[i].name.toLowerCase().replace(" ", "") === playerName.toLowerCase().replace(" ", "")) {

                    numDupes++;

                    if (numDupes == 2) {
                        var deferred = $q.defer();

                        $timeout(function () {
                            deferred.reject({
                                message: "Player already exists in this inhouse"
                            });
                        }, 0);

                        return deferred.promise;
                    }
                }
            }

            return $http.get("/api/inhouse/player/" + playerName).then(function(response) {
                return response.data;
            });
        }
        
        function removePlayer(playerId) {
            var deferred = $q.defer();
            
            $timeout(function() {
                deferred.resolve();
            }, 0);
            
            return deferred.promise;
        }
        
        function balanceTeams() {
            var inhouseModel = {
                blueTeam: blueTeam,
                redTeam: redTeam
            };

            return $http.post("/api/inhouse/balance", inhouseModel).then(function(response) {
                var swaps = response.data;

                for (var i = 0; i < swaps.blueSwaps.length; i++) {
                    for (var j = 0; j < blueTeam.length; j++) {
                        if (swaps.blueSwaps[i].id == blueTeam[j].id) {
                            blueTeam[j].status = "swapping";
                        }
                        
                        if (swaps.redSwaps[i].id == redTeam[j].id) {
                            redTeam[j].status = "swapping";
                        }
                    }
                }

                for (var i = 0; i < blueTeam.length; i++) {
                    if (blueTeam[i].status != "swapping") {
                        blueTeam[i].status = "locked";
                    }

                    if (redTeam[i].status != "swapping") {
                        redTeam[i].status = "locked";
                    }
                }

                return swaps.ratingDifference;
            });
        }
        
        function swapPlayers() {
            var deferred = $q.defer();
            
            $timeout(function() {

                var blueSwaps = [];
                var redSwaps = [];

                for (var i = 0; i < 5; i++) {
                    var bluePlayer = blueTeam[i];
                    var redPlayer = redTeam[i];

                    if (bluePlayer.status == "swapping") {
                        blueSwaps.push(bluePlayer);
                   }
                   
                    if (redPlayer.status == "swapping") {
                        redSwaps.push(redPlayer);
                   }
                   
                   bluePlayer.status = "confirmed";
                   redPlayer.status = "confirmed";
                }

                for (var i = 0; i < blueSwaps.length; i++) {
                    var blueIndex = blueTeam.indexOf(blueSwaps[i]);
                    var redIndex = redTeam.indexOf(redSwaps[i]);

                    blueTeam.splice(blueIndex, 1);
                    redTeam.splice(redIndex, 1);

                    blueTeam.push(redSwaps[i]);
                    redTeam.push(blueSwaps[i]);
                }

                deferred.resolve();
            }, 0);
            
            return deferred.promise;
        }
    }
    
})();
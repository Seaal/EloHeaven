(function() {
    
    angular
        .module("eloHeaven.inhouses")
        .factory("inhouseService", inhouseService);
        
    function inhouseService($http, $q, $timeout) {
        return {
            addPlayer: addPlayer,
            removePlayer: removePlayer,
            balanceTeams: balanceTeams,
            swapPlayers: swapPlayers
        };
        
        function addPlayer(playerName) {
            return $http.get("/api/inhouse/player/" + playerName).then(function(response) {
                return response.data;
            });
        }
        
        function removePlayer(playerId) {
            var deferred = $q.defer();
            
            $timeout(function() {
                deferred.resolve();
            }, 100);
            
            return deferred.promise;
        }
        
        function balanceTeams(blueTeam, redTeam) {
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
        
        function swapPlayers(blueTeam, redTeam) {
            var deferred = $q.defer();
            
            $timeout(function() {
               var swaps = {
                  redTeam: [],
                  blueTeam: [] 
               };
               
               for(var i=0; i<5; i++) {
                   var newBluePlayer = angular.copy(blueTeam[i]);
                   var newRedPlayer = angular.copy(redTeam[i]);
                   
                   if(newBluePlayer.status == "swapping") {
                       swaps.redTeam.push(newBluePlayer);
                   } else {
                       swaps.blueTeam.push(newBluePlayer);
                   }
                   
                   if(newRedPlayer.status == "swapping") {
                       swaps.blueTeam.push(newRedPlayer);
                   } else {
                       swaps.redTeam.push(newRedPlayer);
                   }
                   
                   newBluePlayer.status = "confirmed";
                   newRedPlayer.status = "confirmed";
                   
                   deferred.resolve(swaps);
               }
            }, 500);
            
            return deferred.promise;
        }
    }
    
})();
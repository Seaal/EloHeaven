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
            var deferred = $q.defer();
            
            $timeout(function() {
                var swaps = {
                    redTeam: [],
                    blueTeam: []
                };
                
                for(var i=0; i<5;i++) {
                    var newBluePlayer = angular.copy(blueTeam[i]);
                    var newRedPlayer = angular.copy(redTeam[i]);
                    
                    if(Math.random() > 0.75) {
                        newBluePlayer.status = "swapping";
                        newRedPlayer.status = "swapping";
                    } else {
                        newBluePlayer.status = "locked";
                        newRedPlayer.status = "locked";
                    }
                    
                    swaps.blueTeam.push(newBluePlayer);
                    swaps.redTeam.push(newRedPlayer);
                }
                
                deferred.resolve(swaps);
            }, 500);
            
            return deferred.promise;
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
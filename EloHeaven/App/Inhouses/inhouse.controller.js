(function() {
    
    angular
        .module("eloHeaven")
        .controller("inhouseController", InhouseController);
        
    function InhouseController($scope, inhouseService) {
        var vm = this;
        
        vm.playersPerTeam = 5;
        vm.blueTeam = [];
        vm.redTeam = [];
        vm.balanceTeams = balanceTeams;
        vm.cancelSwap = cancelSwap;
        vm.swapPlayers = swapPlayers;
        vm.allConfirmed = false;
        vm.balancing = false;
        
        activate();
        
        function activate() {
            for(var i=0;i<vm.playersPerTeam;i++) {
                vm.blueTeam.push({
                    name: "",
                    status: "empty"
                });
                
                vm.redTeam.push({
                    name: "",
                    status: "empty"
                });
            }
            
            $scope.$watch(angular.bind(vm, function() {
                return this.blueTeam;
            }), watchNoPlayersConfirmed(vm.redTeam), true);
            $scope.$watch(angular.bind(vm, function() {
                return this.redTeam;
            }), watchNoPlayersConfirmed(vm.blueTeam), true);
            
            function watchNoPlayersConfirmed(otherTeam) {
                var watchFunction = function(newValue) {
                    if(!newValue) {
                        return;
                    }
                    
                    var playersConfirmed = 0;
                    
                    for(var i=0;i<newValue.length;i++) {
                        if(newValue[i].status == "confirmed") {
                            playersConfirmed++;
                        }
                    }
                    
                    for(var i=0;i<otherTeam.length;i++) {
                        if(otherTeam[i].status == "confirmed") {
                            playersConfirmed++;
                        }
                    }
                    
                    vm.allConfirmed = playersConfirmed == vm.playersPerTeam * 2;
                }
                
                return watchFunction;
            }
        }
        
        function balanceTeams() {
            inhouseService.balanceTeams(vm.blueTeam, vm.redTeam).then(function(swaps) {
                vm.blueTeam = swaps.blueTeam;
                vm.redTeam = swaps.redTeam;
                
                vm.balancing = true;
            });          
        }
        
        function swapPlayers() {
            inhouseService.swapPlayers(vm.blueTeam, vm.redTeam).then(function(swaps) {
                vm.blueTeam = swaps.blueTeam;
                vm.redTeam = swaps.redTeam;
                
                vm.balancing = false;
            })
        }
        
        function cancelSwap() {
            for(var i=0; i< vm.playersPerTeam; i++) {
                vm.blueTeam[i].status = "confirmed";
                vm.redTeam[i].status = "confirmed";
                vm.balancing = false;
            }
        }
    }
    
})();
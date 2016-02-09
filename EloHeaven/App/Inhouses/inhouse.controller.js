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
        vm.swapping = false;
        
        activate();
        
        function activate() {
            var teams = inhouseService.getTeams();

            vm.blueTeam = teams.blueTeam;
            vm.redTeam = teams.redTeam;
            
            $scope.$watch(angular.bind(vm, function() {
                return this.blueTeam;
            }), watchNoPlayersConfirmed(vm.redTeam), true);
            $scope.$watch(angular.bind(vm, function() {
                return this.redTeam;
            }), watchNoPlayersConfirmed(vm.blueTeam), true);
        }
        
        function balanceTeams() {
            inhouseService.balanceTeams().then(function (balanceInfo) {
                vm.swapping = balanceInfo.hasSwaps;
            });          
        }
        
        function swapPlayers() {
            inhouseService.swapPlayers().then(function (swaps) {
                vm.swapping = false;
                vm.allConfirmed = true;
            });
        }
        
        function cancelSwap() {
            for(var i=0; i< vm.playersPerTeam; i++) {
                vm.blueTeam[i].status = "confirmed";
                vm.redTeam[i].status = "confirmed";
                vm.swapping = false;
            }
        }

        function watchNoPlayersConfirmed(otherTeam) {
            var watchFunction = function (newValue) {
                if (!newValue) {
                    return;
                }

                var playersConfirmed = 0;

                for (var i = 0; i < newValue.length; i++) {
                    if (newValue[i].status == "confirmed") {
                        playersConfirmed++;
                    }
                }

                for (var i = 0; i < otherTeam.length; i++) {
                    if (otherTeam[i].status == "confirmed") {
                        playersConfirmed++;
                    }
                }

                vm.allConfirmed = playersConfirmed == vm.playersPerTeam * 2;
            }

            return watchFunction;
        }
    }
    
})();
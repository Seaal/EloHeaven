(function() {
    
    angular
        .module("eloHeaven.inhouses")
        .directive("ehPlayerCard", playerCard);
        
    function playerCard() {
        var directive = {
            restrict: 'E',
            templateUrl: 'App/Inhouses/playerCard.html',
            scope: {
                player: "="
            },
            controllerAs: 'card',
            bindToController: true,
            controller: controller
        };
        
        return directive;
        
        function controller(inhouseService) {
            var vm = this;
            
            vm.validatePlayer = validatePlayer;
            vm.removePlayer = removePlayer;
            vm.confirmedSummoner = {};
            vm.errorMessage = "";
            
            var lastSearch = "";
            
            function validatePlayer(player) {
                if(!player.name) {
                    return;
                }
                
                if(player.name == lastSearch) {
                    return;
                }
                
                vm.errorMessage = "";
                
                lastSearch = player.name;
                
                inhouseService.addPlayer(player.name).then(function(player) {
                    vm.player.id = player.id;
                    vm.player.name = player.name;
                    vm.player.rank = player.rank;
                    vm.player.region = player.region;
                    vm.player.status = player.status;
                }, function (error) {
                    if (error.status == 404) {
                        vm.errorMessage = "Player could not be found.";
                    } else {
                        vm.errorMessage = "An error occurred. Please try again later.";
                    }
                    
                });
            }
            
            function removePlayer(player) {
                inhouseService.removePlayer(player.id).then(function() {
                   vm.player.id = player.id;
                   vm.player.name = "";
                   vm.player.rank = "";
                   vm.player.region = "";
                   vm.player.status = "empty";
                   
                   lastSearch = "";
                });
            }
        }
    }
    
})();
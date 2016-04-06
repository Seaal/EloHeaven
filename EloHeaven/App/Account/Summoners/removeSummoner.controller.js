(function() {

    angular
        .module("eloHeaven")
        .controller("removeSummonerController", RemoveSummonerController);

    RemoveSummonerController.$inject = ["$scope", "accountService", "summoner"];

    function RemoveSummonerController($scope, accountService, summoner) {
        var vm = this;

        vm.summoner = summoner;
        vm.remove = remove;

        function remove() {
            accountService.removeSummoner(1, summoner.id).then(function() {
                $scope.$close();
            });
        }
    }


})();
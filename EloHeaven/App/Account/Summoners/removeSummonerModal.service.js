(function() {

    angular
        .module("eloHeaven")
        .factory("removeSummonerModalService", removeSummonerModalService);

    removeSummonerModalService.$inject = ["$uibModal"];

    function removeSummonerModalService($uibModal) {
        var service = {
            open: open
        };

        return service;

        function open(summoner) {
            var removeModal = $uibModal.open({
                templateUrl: "App/Account/Summoners/removeSummoner.view.html",
                controller: "removeSummonerController",
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    summoner: function () {
                        return summoner;
                    }
                }
            });

            return removeModal.result;
        }
    }

})();
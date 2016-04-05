(function() {

    angular
        .module("eloHeaven")
        .factory("verifySummonerModalService", verifySummonerModalService);

    function verifySummonerModalService($uibModal) {
        var service = {
            open: open
        };

        return service;

        function open(verifySummonerModel) {
            var verifyModal = $uibModal.open({
                templateUrl: "App/Account/Summoners/verifySummoner.html",
                controller: "verifySummonerController",
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    verifySummonerModel: function () {
                        return verifySummonerModel;
                    }
                }
            });

            return verifyModal.result;
        }
    }

})();
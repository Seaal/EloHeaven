(function() {

    angular
        .module("eloHeaven")
        .factory("confirmSummonerModalService", confirmSummonerModalService);

    function confirmSummonerModalService($uibModal) {
        var service = {
            open: open
        };

        return service;

        function open(confirmSummonerModel) {
            var confirmModal = $uibModal.open({
                templateUrl: "App/Account/Summoners/confirmSummoner.html",
                controller: "confirmSummonerController",
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    confirmSummoner: function () {
                        return confirmSummonerModel;
                    }
                }
            });

            return confirmModal.result;
        }
    }

})();
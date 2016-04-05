(function () {
    'use strict';

    angular
        .module("eloHeaven.core")
        .directive("ehSummonerList", function () {
            var directive = {
                restrict: 'E',
                scope: {
                    summoners: '='
                },
                templateUrl: 'App/Core/summonerList.html',
                controllerAs: 'vm',
                bindToController: true,
                controller: controller
            };

            return directive;
        });

    function controller(accountService, confirmSummonerModalService) {

        var vm = this;

        vm.confirmSummoner = confirmSummoner;

        function confirmSummoner(summoner) {
            accountService.getSummonerConfirmation(1, summoner.id).then(function(confirmationModel) {
                confirmSummonerModalService.open(confirmationModel).then(function() {
                    summoner.isVerified = true;
                });
            });
        }

    }
})();
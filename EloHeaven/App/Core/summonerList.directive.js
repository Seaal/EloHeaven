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

    function controller(accountService, verifySummonerModalService) {

        var vm = this;

        vm.verifySummoner = verifySummoner;

        function verifySummoner(summoner) {
            accountService.getSummonerVerification(1, summoner.id).then(function(confirmationModel) {
                verifySummonerModalService.open(confirmationModel).then(function(newSummoner) {
                    summoner.isVerified = newSummoner.isVerified;
                });
            });
        }

    }
})();
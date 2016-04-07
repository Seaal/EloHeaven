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
                templateUrl: 'App/Core/summonerList.template.html',
                controllerAs: 'vm',
                bindToController: true,
                controller: controller
            };

            return directive;
        });

    function controller(accountService, verifySummonerModalService, removeSummonerModalService) {

        var vm = this;

        vm.verifySummoner = verifySummoner;
        vm.remove = remove;

        function verifySummoner(summoner) {
            accountService.getSummonerVerification(1, summoner.id).then(function(confirmationModel) {
                verifySummonerModalService.open(confirmationModel).then(function(newSummoner) {
                    summoner.isVerified = newSummoner.isVerified;
                });
            });
        }

        function remove(summoner) {
            removeSummonerModalService.open(summoner).then(function() {
                var index = vm.summoners.indexOf(summoner);
                vm.summoners.splice(index, 1);
            });
        }

    }
})();
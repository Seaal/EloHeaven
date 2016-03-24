﻿(function() {

    angular
        .module("eloHeaven")
        .directive("ehLeagueAccounts", leagueAccounts);

    function leagueAccounts() {
        var directive = {
            restrict: "E",
            scope: {
                summoners: "=summoners",
                regions: "=regions"
            },
            templateUrl: "/App/Account/Summoners/leagueAccounts.template.html",
            controllerAs: "accounts",
            bindToController: true,
            controller: controller
        }

        return directive;
    }

    function controller($uibModal, accountService) {

        var vm = this;

        vm.addSummoner = addSummoner;
        vm.summonerName = "";
        vm.summonerRegion = vm.regions[0].id;
        vm.errors = [];

        function addSummoner(name, region) {

            vm.errors.length = 0;

            if (name === "") {
                vm.errors.push({ message: "Account Name cannot be empty." });
            }

            if (region === "") {
                vm.errors.push({ message: "Please select a region." });
            }

            if (vm.errors.length > 0) {
                return;
            }

            accountService.addSummoner("581597B2-6D99-4274-8411-0184BE889292", { name: vm.summonerName, region: vm.summonerRegion }).then(function(confirmSummoner) {
                var confirmModal = $uibModal.open({
                    templateUrl: "App/Account/Summoners/confirmSummoner.html",
                    controller: "confirmSummonerController",
                    controllerAs: "vm",
                    backdrop: "static",
                    resolve: {
                        confirmSummoner: function () {
                            return confirmSummoner;
                        }
                    }
                });

                confirmModal.result.then(function (summoner) {
                    vm.summoners.push(summoner);

                    vm.summonerName = "";
                });
            }, function(error) {
                vm.errors.push(error);
            });
        }
    }

})();
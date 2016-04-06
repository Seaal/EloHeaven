(function() {

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

    function controller(verifySummonerModalService, accountService) {

        var vm = this;

        vm.addSummoner = addSummoner;
        vm.summonerName = "";
        vm.summonerRegion = vm.regions[0];
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

            accountService.addSummoner(1, { name: vm.summonerName, region: vm.summonerRegion }).then(function(verifySummoner) {
                verifySummonerModalService.open(verifySummoner).then(function (summoner) {
                    vm.summoners.push(summoner);

                    vm.summonerName = "";
                });
            }, function(error) {
                vm.errors.push(error);
            });
        }
    }

})();
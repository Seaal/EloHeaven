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
            templateUrl: "/App/Account/leagueAccounts.template.html",
            controllerAs: "accounts",
            bindToController: true,
            controller: controller
        }

        return directive;
    }

    function controller() {

        var vm = this;

        activate();

        function activate() {
            vm.summonerName = "";
            vm.summonerRegion = vm.regions[0].id;
        }
    }

})();
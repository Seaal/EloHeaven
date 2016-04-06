(function() {

    angular
        .module("eloHeaven")
        .controller("accountController", AccountController);

    function AccountController(summoners, regions) {
        var vm = this;

        vm.summoners = summoners;
        vm.regions = regions;
    }

})();
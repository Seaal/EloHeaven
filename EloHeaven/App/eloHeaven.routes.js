(function() {
	angular
		.module("eloHeaven")
		.config(routes);
		
	function routes($stateProvider, $urlRouterProvider) {
		$urlRouterProvider.otherwise("/inhouses/");
		
		$stateProvider
            .state("inhouses", {
                url: "/inhouses/",
                templateUrl: "/App/Inhouses/inhouse.view.html",
                controller: "inhouseController as inhouse"
            })
            .state("account", {
                url: "/account/",
                templateUrl: "/App/Account/account.view.html",
                controller: "accountController as account",
                resolve: {
                    summoners: function(accountService) {
                        return accountService.getSummoners("581597B2-6D99-4274-8411-0184BE889292");
                    },
                    regions: function(regionService) {
                        return regionService.getAll();
                    }
                }
		    });
	}
})();
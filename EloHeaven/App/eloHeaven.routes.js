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
                        return accountService.getSummoners(1);
                    },
                    regions: function(regionService) {
                        return regionService.getAll();
                    }
                }
		    });
	}
})();
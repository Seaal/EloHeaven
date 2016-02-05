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
            });			
	}
})();
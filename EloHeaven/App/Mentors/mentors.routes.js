(function() {
	angular
		.module("eloHeaven.mentors")
		.config(routes);
		
	function routes($stateProvider, $urlRouterProvider, applicationServiceProvider) {
		$urlRouterProvider.otherwise("/mentors/search");
	}
})();
(function() {
	angular
		.module("eloHeaven.mentors")
		.config(routes);
		
	function routes($stateProvider, $urlRouterProvider, applicationServiceProvider) {
		$urlRouterProvider.otherwise("/mentors/search");
		
		var applicationService = applicationServiceProvider.$get();
		
		$stateProvider
			.state("apply", {
				url: "/mentors/apply",
				abstract: true,
				templateUrl: "/App/Mentors/Application/application.view.html",
				controller: "applicationController as application"
			})
			.state("apply.terms", {
				url: "",
				templateUrl: "/App/Mentors/Application/terms/terms.view.html",
				controller: "termsController as application",
				data: { step: applicationService.getStepNumber("apply.terms") }
			})
			.state("apply.summoners", {
				url: "/summoners",
				templateUrl: "/App/Mentors/Application/summoners/addSummoners.view.html",
				controller: "addSummonersController as application",
				data: { step: applicationService.getStepNumber("apply.summoners") }
			})
			.state("apply.basicInfo", {
				url: "/basicinfo",
				templateUrl: "/App/Mentors/Application/basicInfo/basicInfo.view.html",
				controller: "basicInfoController as application",
				data: { step: applicationService.getStepNumber("apply.basicInfo") }
			})
			.state("apply.availability", {
				url: "/availability",
				templateUrl: "/App/Mentors/Application/availability/availability.view.html",
				controller: "availabilityController as application",
				data: { step: applicationService.getStepNumber("apply.availability") }
			})
			.state("apply.bio", {
				url: "/bio",
				templateUrl: "/App/Mentors/Application/bio/bio.view.html",
				controller: "bioController as application",
				data: { step: applicationService.getStepNumber("apply.bio") }
			})
			.state("apply.confirmation", {
				url: "/confirmation",
				templateUrl: "/App/Mentors/Application/confirmation/confirmation.view.html",
				controller: "confirmationController as application",
				data: { step: applicationService.getStepNumber("apply.confirmation") }
			})
			
	}
})();
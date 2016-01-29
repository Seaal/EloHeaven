(function() {
	angular
		.module("eloHeaven.mentors")
		.controller("termsController", TermsController);
		
	function TermsController($scope, $window, applicationService) {
		var vm = this;
		
		vm.acceptedTerms = false;
		
		$scope.$on("nextStep", nextStep);
		$scope.$on("$stateChangeStart", saveChanges);
		
		$window.onbeforeunload = saveChanges;
		
		activate();
		
		function activate() {
			var acceptedTerms = applicationService.getStepData("terms");
			
			if(acceptedTerms === "true") {
				vm.acceptedTerms = true;
			}
		}
		
		function saveChanges() {
			applicationService.saveStepData("terms", vm.acceptedTerms);
		}
		
		function nextStep(event, errors) {
			
			if(!vm.acceptedTerms) {					
				errors.push({ message: 'You need to accept the terms to continue.' });
			}
		}
	}
})();
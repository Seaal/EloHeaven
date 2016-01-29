(function() {
	angular
		.module("eloHeaven.mentors")
		.controller("applicationController", Application);
		
	function Application($scope, $state, applicationService) {
		var vm = this;
		
		vm.currentStep = "";
		vm.errors = [];
		vm.previousStep = previousStep;
		vm.nextStep = nextStep;
		vm.totalSteps = 0;
		
		activate();
		
		function activate() {
			vm.totalSteps = applicationService.getTotalSteps();
			
			var highestStepReached = applicationService.getHighestStepReached();
			
			if(highestStepReached === null) {
				applicationService.saveHighestStepReached(1);
			}
		}
		
		function nextStep(currentStep) {
			
			vm.errors.length = 0;
			
			$scope.$broadcast("nextStep", vm.errors);
			
			if(vm.errors.length === 0) {
				
				var highestStepReached = applicationService.getHighestStepReached();
				
				if(highestStepReached < vm.currentStep + 1) {
					applicationService.saveHighestStepReached(vm.currentStep + 1);
				}
				
				var nextStep = applicationService.getNextStep(currentStep);
			
				$state.go(nextStep);
				
			}
		}
		
		function previousStep(currentStep) {
			var previousStep = applicationService.getPreviousStep(currentStep);
			
			$state.go(previousStep);
		}
		
		$scope.$on('$stateChangeSuccess', function(event, toState) {
			
			var highestStepReached = applicationService.getHighestStepReached();
			
			if(highestStepReached && highestStepReached < toState.data.step) {
				var highestStep = applicationService.getStep(highestStepReached);
				
				$state.go(highestStep);
				
				return;
			}
			
			vm.errors.length = 0;
			vm.currentStep = toState.data.step;
		});
	}
})();
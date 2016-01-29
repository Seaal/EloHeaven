(function() {
	
	angular
		.module("eloHeaven.mentors")
		.controller("bioController", BioController);
		
	function BioController($scope, applicationService) {
		var vm = this;
		
		vm.specialities = [];
		vm.summary = "";
		vm.aboutMentor = "";
		vm.maxSummaryLength = 500;
		vm.maxSpecialityNumber = 5;
		vm.addSpeciality = addSpeciality;
		vm.removeSpeciality = removeSpeciality;
		vm.submitted = false;
		vm.specialitySubmitted = false;
		vm.errors = {};
		
		$scope.$on("$stateChangeStart", onStateChange);
		
		activate();
		
		function activate() {
			var bioData = applicationService.getStepData("bio");
			
			if(bioData !== null) {
				vm.specialities = bioData.specialities;
				vm.summary = bioData.summary;
				vm.aboutMentor = bioData.aboutMentor;
			}
			
			vm.errors = {
				specialities: ["", "", "", "", ""],
				summary: "",
				aboutMentor: ""
			}
			
			if(vm.specialities.length == 0) {
				vm.specialities.push({ text: "" });
			}
		}
		
		function addSpeciality() {
			if(vm.specialityForm.$valid) {
				vm.specialities.push({ text: "" });
				vm.specialitySubmitted = false;
			} else {
				vm.specialitySubmitted = true;
			}
		}
		
		function removeSpeciality(index) {
			if(vm.specialities.length == 1) {
				vm.specialities[0].text = "";
			} else {
				vm.specialities.splice(index, 1);
			}
		}
		
		function onStateChange(event, toState) {
			if(toState.name == applicationService.getNextStep(applicationService.getStepNumber("apply.bio")) && !vm.form.$valid) {
				event.preventDefault();
				vm.submitted = true;
			} else {							
				saveChanges();
			}
		}
		
		function saveChanges() {
			var bioData = {
				specialities: vm.specialities,
				summary: vm.summary,
				aboutMentor: vm.aboutMentor
			};
			
			applicationService.saveStepData("bio", bioData);
		}
		
		function nextStep() {
			
		}
	}
	
})();
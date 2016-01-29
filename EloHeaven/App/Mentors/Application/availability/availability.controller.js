(function() {
	
	angular
		.module("eloHeaven.mentors")
		.controller("availabilityController", AvailabilityController);
		
		function AvailabilityController($interval) {
			var vm = this;
			
			vm.currentTime = new Date();
			
			$interval(function() {
				vm.currentTime = new Date();
			}, 1000);
			
			vm.availabilityOptions = [
				{ id: 1, name: "Sporadic" },
				{ id: 2, name: "The same time every day"},
				{ id: 3, name: "Specify times for each day" }
			];
			
			vm.contactPreferences = [
				{ id: 1, name: "In-game PM", selected: false },
				{ id: 2, name: "TeamSpeak PM", selected: false },
				{ id: 3, name: "Enjin PM", selected: false }
			]
		}
	
})();
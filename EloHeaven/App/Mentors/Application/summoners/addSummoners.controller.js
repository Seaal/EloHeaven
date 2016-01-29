(function() {
	angular
		.module("eloHeaven.mentors")
		.controller("addSummonersController", AddSummonerController);
		
	function AddSummonerController($modal, $scope, $window, leagueApiService, applicationService) {
		var vm = this;
		
		vm.addSummoner = addSummoner;
		vm.regions = [];
		vm.summoners = [];
		vm.summonerName = "";
		vm.summonerRegion = "";
		vm.errors = [];
		
		$scope.$on("nextStep", nextStep);
		$scope.$on("$stateChangeStart", saveChanges);
		
		$window.onbeforeunload = saveChanges;
		
		activate();
		
		function activate() {
			
			var summoners = applicationService.getStepData("summoners");
			
			if(summoners !== null) {
				vm.summoners = summoners;
			}
			
			vm.regions = leagueApiService.getRegions();
		}
		
		function nextStep(event, errors) {
				
			vm.errors.length = 0;
			
			if(vm.summoners.length == 0) {					
				errors.push({ message: 'You need a Ranked Level 30 account to continue.' });
			}
		}
		
		function saveChanges() {
			applicationService.saveStepData("summoners", vm.summoners);
		}
		
		function addSummoner(name, region) {
			
			vm.errors.length = 0;
			
			if(name == "") {
				vm.errors.push({ message: 'Account Name cannot be empty.' });
			}
			
			if(region === "") {
				vm.errors.push({ message: 'Please select a region.' });
			}
			
			if(vm.errors.length > 0) {
				return;
			}
			
			var summoner = leagueApiService.getSummoner(name, region);
			
			var confirmModal = $modal.open({
				templateUrl: 'App/Mentors/Application/summoners/confirmSummoner.html',
				controller: 'confirmSummonerController',
				controllerAs: 'vm',
				backdrop: 'static',
				resolve: {
					summoner: function() {
						return summoner;
					}
				}
			});
			
			confirmModal.result.then(function(summoner) {
				vm.summoners.push(summoner);
				
				vm.summonerName = "";
				vm.summonerRegion = "";
			});
		}
	}
})();
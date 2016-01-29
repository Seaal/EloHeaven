(function() {
	
	angular
		.module("eloHeaven.mentors")
		.controller("confirmSummonerController", ConfirmSummonerController);
		
	function ConfirmSummonerController($scope, applicationService, leagueApiService, summoner) {
		var vm = this;
		
		vm.summoner = summoner;
		vm.code = "";
		vm.confirm = confirm;
		
		activate();
		
		function activate() {
			vm.code = applicationService.getRandomCode();
		}
		
		function confirm(summoner, code) {
			if(leagueApiService.confirmSummoner(summoner, code)) {
				$scope.$close(summoner);
			}
		}
	}
	
})();
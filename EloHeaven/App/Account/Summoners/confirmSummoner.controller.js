(function() {
	
	angular
		.module("eloHeaven")
		.controller("confirmSummonerController", ConfirmSummonerController);
		
	function ConfirmSummonerController($scope, accountService, confirmSummoner) {
		var vm = this;
		
		vm.summoner = confirmSummoner.summoner;
		vm.code = confirmSummoner.code;
		vm.confirm = confirm;
	    vm.error = "";
		
		function confirm() {
		    vm.error = "";

		    accountService.confirmSummoner("581597B2-6D99-4274-8411-0184BE889292", confirmSummoner.summoner.id).then(function () {
		        $scope.$close(confirmSummoner.summoner);
		    }, function(response) {
		        vm.error = response.data.message;
		    });
		}
	}
	
})();
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

		    accountService.confirmSummoner(1, confirmSummoner.summoner.id).then(function () {
		        $scope.$close(confirmSummoner.summoner);
		    }, function(response) {
		        vm.error = response.data.message;
		    });
		}
	}
	
})();
(function() {
	
	angular
		.module("eloHeaven")
		.controller("verifySummonerController", VerifySummonerController);
		
	function VerifySummonerController($scope, accountService, verifySummonerModel) {
		var vm = this;
		
		vm.summoner = verifySummonerModel.summoner;
	    vm.cancel = cancel;
		vm.code = verifySummonerModel.code;
		vm.verify = verify;
	    vm.verifyLater = verifyLater;
	    vm.error = "";
		
		function verify() {
		    vm.error = "";

		    accountService.verifySummoner(1, vm.summoner.id).then(function () {

		        vm.summoner.isVerified = true;

		        $scope.$close(vm.summoner);
		    }, function(response) {
		        vm.error = response.data.message;
		    });
		}

        function verifyLater() {
            $scope.$close(vm.summoner);
        }
        
        function cancel() {
            accountService.removeSummoner(1, vm.summoner.id).then(function() {
                $scope.$dismiss();
            });
        }
	}
	
})();
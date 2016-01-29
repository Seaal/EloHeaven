(function() {
	angular
		.module("eloHeaven.mentors")
		.controller("basicInfoController", BasicInfoController);
		
	function BasicInfoController() {
		var vm = this;
		
		activate();
		
		function activate() {
			vm.selectedChampions = [{ name: 'Lux', imageUrl: 'images/lux-48.jpg' },
                    				{ name: 'Shaco', imageUrl: 'images/shaco-48.jpg' }];
		}
	}
})();
(function() {
	
	angular
		.module("seaal")
		.directive("seaalTimezonePicker", timezonePicker);
		
	function timezonePicker() {
		var directive = {
			restrict: 'E',
			templateUrl: 'App/Shared/timezonePicker.template.html',
			scope: {
				selectedTimezone: "="
			},
			controllerAs: "vm",
			bindToController: true,
			controller: controller
		}
		
		return directive;
		
		function controller(jstz, timezoneData) {
			var vm = this;
			
			if(!vm.selectedTimezone) {
				vm.selectedTimezone = jstz.determine().name();
			}
			
			vm.selectConfig = {
				valueField: 'name',
				labelField: 'name',
				maxItems: 1,
				searchField: 'name'
			};
			
			vm.timezones = timezoneData;
		}
	}
	
})();
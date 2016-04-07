(function() {
	
	angular
		.module("eloHeaven.mentors")
		.directive("ehChampionList", function() {
			return {
				restrict: 'E',
				templateUrl: 'App/Mentors/championList.template.html',
				bindToController: true,
				scope: {
					readOnly: "=?",
					editMode: "=?",
					initialSelectedChampions: '=selectedChampions',
					size: "@"
				},
				controllerAs: "list",
				controller: function(championListService) {
					var vm = this;
					
					vm.cancel = cancel;
					vm.championNumber = vm.initialSelectedChampions.length;
					vm.edit = edit;
					vm.editChampions = [];
					vm.filterString = "";
					vm.maxChampionNumber = 10;
					vm.save = save;
					vm.selectChampion = selectChampion;
					vm.selectedChampions = [];
					vm.sortableOptions = {};
					
					activate();
					
					function activate() {
						if(vm.editMode === undefined) {
							vm.editMode = false;
						}
						
						if(vm.readOnly === undefined) {
							vm.readOnly = true;
						}
						
						if(vm.size === undefined) {
							vm.size = "small";
						}
						
						if(!vm.readOnly) {
							vm.editChampions = championListService.getAllChampions();
							championListService.setAllChampionsSelected(vm.initialSelectedChampions);
							championListService.setSelectedChampions(vm.selectedChampions);
						}
						
						vm.sortableOptions = {
							disabled: vm.readOnly,
							helper: 'clone', 
							opacity: 0.5,
							scroll: false,
							start: sortStart,
							cursor: 'move',
							stop: sortStop
						};
					}
					
					function edit() {
						vm.filterString = "";					
						vm.editMode = true;
					}
					
					function save() {
						championListService.setSelectedChampions(vm.selectedChampions);
						
						vm.editMode = false;
					}
					
					function cancel() {
						championListService.setAllChampionsSelected(vm.selectedChampions);
						
						vm.editMode = false;
					}
					
					function selectChampion(champion) {
						if(!champion.selected) {
							if(vm.championNumber < vm.maxChampionNumber) {
								champion.selected = true;
								vm.championNumber++;
							}
						}
						else {
							champion.selected = false;
							vm.championNumber--;
						}
					}
					
					function sortStart(e, ui) {
						//Fix for the list elements when a champion is being moved
						ui.placeholder.html('&nbsp;');
						
						//Fix for inconsistent reordering of champions
						$(e.target).data("ui-sortable").floating = true;
					}
					
					function sortStop() {
						championListService.sortChampions(vm.selectedChampions);
					}
				}
			};
		});
	
})();
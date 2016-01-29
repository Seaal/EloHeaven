(function() {
    'use strict';

    angular
        .module("eloHeaven.mentors")
        .controller("searchController", SearchController);

    function SearchController(searchService) {
        var vm = this;

        vm.mentors = [];
        vm.searchString = "";
        vm.search = search;
        vm.user = {};

        activate();

        function activate() {
        }

        function search(searchString) {
            searchService.performSearch(searchString)
                .then(function (mentors) {
                    vm.mentors = mentors;
                });
        }
    }

})();
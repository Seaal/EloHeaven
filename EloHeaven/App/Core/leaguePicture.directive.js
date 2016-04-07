(function () {
    'use strict';

    angular
        .module("eloHeaven.core")
        .directive("ehLeaguePicture", leaguePicture);

    function leaguePicture() {
        var directive = {
            restrict: 'E',
            templateUrl: 'App/Core/leaguePicture.template.html',
            scope: {
                size: '@',
                summoner: '=',
                alt: '@'
            },
            controllerAs: 'vm',
            bindToController: true,
            replace: true,
            controller: function () {
                var vm = this;
            }
        };

        return directive;
    }


})();
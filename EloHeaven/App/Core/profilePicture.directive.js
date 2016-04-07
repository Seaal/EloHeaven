(function () {
    'use strict';

    angular
        .module("eloHeaven.core")
        .directive("ehProfilePicture", profilePicture);

    function profilePicture() {
        var directive = {
            restrict: 'E',
            templateUrl: 'App/Core/profilePicture.template.html',
            scope: {
                size: '@',
                user: '='
            },
            controllerAs: 'vm',
            bindToController: true,
            controller: function () {
                var vm = this;
            }
        };

        return directive;
    }


})();
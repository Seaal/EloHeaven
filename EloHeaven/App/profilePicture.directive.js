/// <reference path="../typings/angularjs/angular.d.ts"/>
(function () {
    'use strict';

    angular
        .module("eloHeaven")
        .directive("ehProfilePicture", profilePicture);

    function profilePicture() {
        var directive = {
            restrict: 'E',
            templateUrl: 'App/profilePicture.html',
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
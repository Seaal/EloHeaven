(function () {
    'use strict';

    angular
        .module("eloHeaven.core")
        .directive("ehMentorCard", function () {
            var directive = {
                restrict: 'E',
                scope: {
                    mentor: '='
                },
                templateUrl: 'App/Core/mentorCard.template.html'
            };

            return directive;
        });
})();

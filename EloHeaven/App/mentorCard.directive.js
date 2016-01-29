(function () {
    'use strict';

    angular
        .module("eloHeaven")
        .directive("ehMentorCard", function () {
            var directive = {
                restrict: 'E',
                scope: {
                    mentor: '='
                },
                templateUrl: 'App/mentorCard.html'
            };

            return directive;
        });
})();

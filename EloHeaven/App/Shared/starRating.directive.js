(function () {
    'use strict';

    angular
        .module("seaal")
        .directive("seaalStarRating", function () {
            var directive = {
                restrict: 'E',
                scope: {
                    rating: "=",
                    readOnly: "="
                },
                bindToController: true,
                templateUrl: 'App/Shared/starRating.template.html',
                controllerAs: 'vm',
                controller: function ($scope, starRatingService) {

                    var vm = this;

                    vm.stars = [];
                    vm.ratingText = "";

                    activate();

                    function activate() {
                        updateStarRating($scope.rating);

                        $scope.$watch(angular.bind(vm, function () {
                            return this.rating;
                        }), updateStarRating);
                    }

                    function updateStarRating(rating) {
                        vm.ratingText = starRatingService.getRatingText(rating);
                        vm.stars = starRatingService.getStars(rating);
                    }
                }
            }

            return directive;
        });
})();

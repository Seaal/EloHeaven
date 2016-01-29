(function () {
    'use strict';

    angular
        .module("eloHeaven.core")
        .directive("ehSummonerList", function () {
            var directive = {
                restrict: 'E',
                scope: {
                    summoners: '='
                },
                templateUrl: 'App/Core/summonerList.html',
                controllerAs: 'vm',
                bindToController: true,
                controller: function() {
                    
                }
            };

            return directive;
        });
})();
(function() {

    angular
        .module("eloHeaven")
        .factory("accountService", accountService);

    function accountService($http) {
        var service = {
            getSummoners: getSummoners
        };

        return service;

        function getSummoners(userId) {
            return $http.get("/api/account/" + userId + "/summoner").then(function(response) {
                return response.data;
            });
        }
    }

})();
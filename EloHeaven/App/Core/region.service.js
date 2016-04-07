(function() {

    angular
        .module("eloHeaven.core")
        .factory("regionService", regionService);

    function regionService($http) {
        var service = {
            getAll: getAll
        };

        return service;

        function getAll() {
            return $http.get("/api/region").then(function(response) {
                return response.data;
            });
        }
    }

})();
(function() {

    angular
        .module("seaal")
        .factory("requestService", requestService);

    requestService.$inject = ["$http"];

    function requestService($http) {
        var baseUrl = "/api/";

        var service = {
            get: get,
            post: post,
            put: put,
            delete: deleteRequest
        };

        return service;

        function get(url) {
            return $http.get(baseUrl + url).then(getData);
        }

        function post(url, data) {
            return $http.post(baseUrl + url, data).then(getData);
        }

        function put(url, data) {
            return $http.put(baseUrl + url, data).then(getData);
        }

        function deleteRequest(url)
        {
            return $http.delete(baseUrl + url).then(getData);
        }

        function getData(response) {
            return response.data;
        }
    }

})();
(function() {

    angular
        .module("eloHeaven")
        .factory("accountService", accountService);

    function accountService($http) {
        var service = {
            getSummoners: getSummoners,
            addSummoner: addSummoner,
            confirmSummoner: confirmSummoner,
            getSummonerConfirmation: getSummonerConfirmation
    };

        return service;

        function getSummoners(userId) {
            return $http.get("/api/account/" + userId + "/summoner").then(function(response) {
                return response.data;
            });
        }

        function addSummoner(userId, summoner) {
            return $http.post("/api/account/" + userId + "/summoner", summoner).then(function(response) {
                return response.data;
            });
        }

        function confirmSummoner(userId, summonerId) {
            return $http.post("/api/account/" + userId + "/summoner/" + summonerId + "/confirmation");
        }

        function getSummonerConfirmation(userId, summonerId) {
            return $http.get("/api/account/" + userId + "/summoner/" + summonerId + "/confirmation").then(function(response) {
                return response.data;
            });
        }
    }

})();
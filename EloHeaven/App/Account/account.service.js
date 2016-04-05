(function() {

    angular
        .module("eloHeaven")
        .factory("accountService", accountService);

    function accountService($http) {
        var service = {
            getSummoners: getSummoners,
            addSummoner: addSummoner,
            verifySummoner: verifySummoner,
            getSummonerVerification: getSummonerVerification
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

        function verifySummoner(userId, summonerId) {
            return $http.post("/api/account/" + userId + "/summoner/" + summonerId + "/verification");
        }

        function getSummonerVerification(userId, summonerId) {
            return $http.get("/api/account/" + userId + "/summoner/" + summonerId + "/verification").then(function(response) {
                return response.data;
            });
        }
    }

})();
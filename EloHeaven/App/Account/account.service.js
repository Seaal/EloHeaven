(function() {

    angular
        .module("eloHeaven")
        .factory("accountService", accountService);

    accountService.$inject = ["requestService"];

    function accountService(requestService) {
        var service = {
            getSummoners: getSummoners,
            addSummoner: addSummoner,
            verifySummoner: verifySummoner,
            getSummonerVerification: getSummonerVerification,
            removeSummoner: removeSummoner
        };

        return service;

        function getSummoners(userId) {
            return requestService.get(getSummonerUrl(userId));
        }

        function addSummoner(userId, summoner) {
            return requestService.post(getSummonerUrl(userId), summoner);
        }

        function verifySummoner(userId, summonerId) {
            return requestService.post(getSummonerUrl(userId, summonerId) + "/verification");
        }

        function getSummonerVerification(userId, summonerId) {
            return requestService.get(getSummonerUrl(userId, summonerId) + "/verification");
        }

        function removeSummoner(userId, summonerId) {
            return requestService.delete(getSummonerUrl(userId, summonerId));
        }

        function getSummonerUrl(userId, summonerId) {
            var url = "account/" + userId + "/summoner";

            return summonerId === undefined ? url : url + "/" + summonerId;
        }
    }

})();
(function () {
    angular
        .module("eloHeaven.core")
        .factory("notificationsService", notificationsService);

    function notificationsService() {
        return {
            getNotifications: function () {
                return 4;
            }
        };
    }
})();
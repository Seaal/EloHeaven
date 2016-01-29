(function () {
    angular
        .module("eloHeaven")
        .factory("notificationsService", notificationsService);

    function notificationsService() {
        return {
            getNotifications: function () {
                return 4;
            }
        };
    }
})();
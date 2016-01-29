(function () {
    angular
        .module("eloHeaven")
        .directive("ehNotificationsList", notificationsList);

    function notificationsList() {
        return {
            restrict: 'E',
            templateUrl: 'App/notificationsList.html',
            scope: {
                user: "="
            },
            controllerAs: 'vm',
            bindToController: true,
            replace: true,
            controller: function (toastr, $timeout, notificationsService) {
                var vm = this;

                vm.toggleNotificationPanel = toggleNotificationPanel;

                activate();

                function activate() {

                    vm.newMessages = notificationsService.getNotifications();
                    vm.showList = false;
                    vm.notifications = [{
                        message: 'Qichin left',
                        image: { url: 'https://avatar.leagueoflegends.com/NA/Qichin.png', text: 'Qichin' }
                    }, {
                        message: 'Qichin left feedback on your mentoring session.',
                        image: { url: 'https://avatar.leagueoflegends.com/NA/Qichin.png', text: 'Qichin' }
                    }, {
                        message: 'Qichin left feedback on your mentoring session.',
                        image: { url: 'https://avatar.leagueoflegends.com/NA/Qichin.png', text: 'Qichin' }
                    }, {
                        message: 'Qichin left feedback on your mentoring session.',
                        image: { url: 'https://avatar.leagueoflegends.com/NA/Qichin.png', text: 'Qichin' }
                    }, {
                        message: 'Seaal has accepted your mentor application.',
                        image: { url: 'https://avatar.leagueoflegends.com/NA/Seaal.png', text: 'Seaal' }
                    }];

                    $timeout(function () {
                        if (!vm.showList) {
                           if (vm.newMessages === "") {
                                vm.newMessages = 1;
                            }
                            else {
                                vm.newMessages++;
                            } 
                        }                        

                        var notification = {
                            message: 'DownsideUp has requested a mentoring session on the 10/05/2015.',
                            image: { url: 'https://avatar.leagueoflegends.com/NA/DownsideUp.png', text: 'DownsideUp' }
                        };

                        vm.notifications.unshift(notification);

                        if (vm.notifications.length > 5) {
                            vm.notifications.pop();
                        }

                        toastr.info(notification.message, 'New Mentor Request', {
                            timeOut: 20000
                        });
                    }, 5000);
                }


                function toggleNotificationPanel(event) {

                    event.stopPropagation();
                    event.preventDefault();

                    toastr.clear();

                    vm.showList = !vm.showList;

                    if (vm.showList) {
                        vm.newMessages = "";
                    }
                }
            }
        };
    }
})();
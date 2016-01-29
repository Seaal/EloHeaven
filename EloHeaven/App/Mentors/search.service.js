(function () {
    'use strict';

    angular
        .module("eloHeaven.mentors")
        .factory("searchService", searchService);

    function searchService($q, $timeout) {
        return {
            performSearch: performSearch
        }

        function performSearch(searchString) {

            var mentors = [{
                name: 'Seaal',
                rank: { name: 'Diamond III', imageUrl: 'images/diamond_3.png' },
                regions: [{ shortName: 'EUW', longName: 'Europe West' }, { shortName: 'NA', longName: 'North America' }],
                profilePictureAccount: { name: 'Seaal', region: 'NA'},
                rating: 1.5,
                lastActive: '2015-05-13 21:28:00',
                champions: [{ name: 'Lux', imageUrl: 'images/lux-48.jpg' },
                    { name: 'Shaco', imageUrl: 'images/shaco-48.jpg' }, { name: 'Ezreal', imageUrl: 'images/ezreal-48.jpg' }, { name: 'Swain', imageUrl: 'images/swain-48.jpg' }, { name: 'Draven', imageUrl: 'images/draven-48.jpg' }, { name: 'Janna', imageUrl: 'images/janna-48.jpg' }, { name: 'Lee Sin', imageUrl: 'images/leesin-48.jpg' }],
                badges: [{ name: 'Experienced Mentor', extraInfo: 'Has completed 30 mentor sessions.' }, { name: 'Instructor', extraInfo: 'Helps out in Mentored Inhouses.' }, { name: 'Admin', extraInfo: 'Helps run Elo Heaven.' }]
            }, {
                name: 'Qichin',
                rank: { name: 'Diamond III', imageUrl: 'images/diamond_3.png' },
                regions: [{ shortName: 'EUW', longName: 'Europe West' }, { shortName: 'NA', longName: 'North America' }],
                profilePictureAccount: { name: 'Qichin', region: 'NA'},
                rating: 5,
                lastActive: '2010-05-06 09:32:00',
                champions: [{ name: 'Lux', imageUrl: 'images/lux-48.jpg' },
                    { name: 'Shaco', imageUrl: 'images/shaco-48.jpg' }, { name: 'Ezreal', imageUrl: 'images/ezreal-48.jpg' }, { name: 'Swain', imageUrl: 'images/swain-48.jpg' }, { name: 'Draven', imageUrl: 'images/draven-48.jpg' }, { name: 'Janna', imageUrl: 'images/janna-48.jpg' }, { name: 'Lee Sin', imageUrl: 'images/leesin-48.jpg' }],
                badges: [{ name: 'Experienced Mentor', extraInfo: 'Has completed 30 mentor sessions.' }, { name: 'Admin', extraInfo: 'Helps run Elo Heaven.' }]
            }];

            var defer = $q.defer();

            $timeout(function () {

                var returnMentors = [];

                var searchParts = searchString.split(" ");

                for (var i = 0; i < searchParts.length; i++) {

                    
                    for (var j = 0; j < mentors.length; j++) {
                        if (mentors[j].name.toLowerCase() == searchParts[i].toLowerCase()) {
                            returnMentors.push(mentors[j]);
                        }
                    }
                    
                }

                defer.resolve(returnMentors);
            }, 100);

            return defer.promise;
        }
    }
})();
(function() {
	angular
		.module("eloHeaven.core")
		.factory("leagueApiService", leagueApiService);
		
	function leagueApiService() {
		return {
			verifySummoner: verifySummoner,
			getChampions: getChampions,
			getSummoner: getSummoner,
			getRegions : getRegions	
		};
		
		function verifySummoner(summoner, code) {
			return true;
		}
		
		function getChampions() {
			return [{ name: 'Aatrox', imageUrl: 'images/aatrox-48.jpg' },
					{ name: 'Ahri', imageUrl: 'images/ahri-48.jpg' },
					{ name: 'Akali', imageUrl: 'images/akali-48.jpg' },
					{ name: 'Alistar', imageUrl: 'images/alistar-48.jpg' },
					{ name: 'Amumu', imageUrl: 'images/amumu-48.jpg' },
					{ name: 'Anivia', imageUrl: 'images/anivia-48.jpg' },
					{ name: 'Annie', imageUrl: 'images/annie-48.jpg' },
					{ name: 'Ashe', imageUrl: 'images/ashe-48.jpg' },
					{ name: 'Azir', imageUrl: 'images/azir-48.jpg' },
					{ name: 'Bard', imageUrl: 'images/bard-48.jpg' },
					{ name: 'Blitzcrank', imageUrl: 'images/blitzcrank-48.jpg' },
					{ name: 'Brand', imageUrl: 'images/brand-48.jpg' },
					{ name: 'Braum', imageUrl: 'images/braum-48.jpg' },
					{ name: 'Caitlyn', imageUrl: 'images/caitlyn-48.jpg' },
					{ name: 'Cassiopeia', imageUrl: 'images/cassiopeia-48.jpg' },
					{ name: 'Cho\'Gath', imageUrl: 'images/chogath-48.jpg' },
					{ name: 'Corki', imageUrl: 'images/corki-48.jpg' },
					{ name: 'Darius', imageUrl: 'images/darius-48.jpg' },
					{ name: 'Diana', imageUrl: 'images/diana-48.jpg' },
					{ name: 'Draven', imageUrl: 'images/draven-48.jpg' },
					{ name: 'Dr. Mundo', imageUrl: 'images/drmundo-48.jpg' },
					{ name: 'Ekko', imageUrl: 'images/ekko-48.jpg' },
					{ name: 'Elise', imageUrl: 'images/elise-48.jpg' },
					{ name: 'Evelynn', imageUrl: 'images/evelynn-48.jpg' },
					{ name: 'Ezreal', imageUrl: 'images/ezreal-48.jpg' },
					{ name: 'Fiddlesticks', imageUrl: 'images/fiddlesticks-48.jpg' },
					{ name: 'Fiora', imageUrl: 'images/fiora-48.jpg' },
					{ name: 'Janna', imageUrl: 'images/janna-48.jpg' },
					{ name: 'Lee Sin', imageUrl: 'images/leesin-48.jpg' },
					{ name: 'Lux', imageUrl: 'images/lux-48.jpg' },
					{ name: 'Shaco', imageUrl: 'images/shaco-48.jpg' },
					{ name: 'Swain', imageUrl: 'images/swain-48.jpg' }];
		}
		
		function getSummoner(name, region) {
			return {
				name: name,
				region: getRegions()[region].shortName,
				rank: "Diamond III"
			};
		}
		
		function getRegions() {
			return [{
				id: 0,
				shortName: "NA",
				longName: "North America"
			}, {
				id: 1,
				shortName: "EUW",
				longName: "Europe West"
			}, {
				id: 2,
				shortName: "EUNE",
				longName: "Europe North & East"
			}];
		}
	}
})();
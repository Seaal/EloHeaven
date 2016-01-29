using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Logic.Common;
using EloHeaven.Logic.LeagueApi.DTOs;

namespace EloHeaven.Logic.LeagueApi
{
    public class LeagueRequestService : ILeagueRequestService
    {
        private readonly IJsonClient _jsonClient;

        private readonly string _riotApi = "https://na.api.pvp.net/api/lol/na/";

        public LeagueRequestService(IJsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public SummonerDTO GetSummoner(string summonerName)
        {
            string resource = GetLeagueResourceUri("v1.4/summoner/by-name/" + summonerName);

            SummonerDTO summonerDto = Get<SummonerDTO>(resource);

            if (summonerDto == null)
            {
                throw new DataNotFoundException("Player could not be found");
            }

            return summonerDto;
        }

        public ICollection<LeagueDTO> GetLeagues(long summonerId)
        {
            string resource = GetLeagueResourceUri("v2.5/league/by-summoner/" + summonerId + "/entry");

            return Get<ICollection<LeagueDTO>>(resource);
        }

        private string GetLeagueResourceUri(string resource)
        {
            string apiKeyDeliminater = resource.Contains('?') ? "&" : "?";
            return _riotApi + resource + apiKeyDeliminater + LeagueApiKey.Key;
        }

        private T Get<T>(string resource)
        {
            Dictionary<string, T> dictionary = _jsonClient.GetRequest<Dictionary<string, T>>(resource);

            if (dictionary == null || !dictionary.Any())
            {
                return default(T);
            }

            return dictionary.First().Value;
        }
    }
}

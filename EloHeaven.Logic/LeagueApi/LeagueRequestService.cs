using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using EloHeaven.Infrastructure.Exceptions;
using EloHeaven.Infrastructure.Extensions;
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

            SummonerDTO summonerDto = Get<SummonerDTO>(resource, () => GetSummoner(summonerName));

            if (summonerDto == null)
            {
                throw new DataNotFoundException("Player could not be found");
            }

            return summonerDto;
        }

        public ICollection<LeagueDTO> GetLeagues(long summonerId)
        {
            string resource = GetLeagueResourceUri("v2.5/league/by-summoner/" + summonerId + "/entry");

            return Get<ICollection<LeagueDTO>>(resource, () => GetLeagues(summonerId));
        }

        private string GetLeagueResourceUri(string resource)
        {
            string apiKeyDeliminater = resource.Contains('?') ? "&" : "?";
            return _riotApi + resource + apiKeyDeliminater + LeagueApiKey.Key;
        }

        private T Get<T>(string resource, Func<T> retryFunc)
        {
            try
            {
                //The riot API loves to return things in a dictionary format
                Dictionary<string, T> dictionary = _jsonClient.GetRequest<Dictionary<string, T>>(resource);

                if (dictionary == null || !dictionary.Any())
                {
                    return default(T);
                }

                return dictionary.First().Value;
            }
            catch (WebException ex)
            {
                HttpStatusCode? statusCode = ex.GetErrorCode();

                if (statusCode.HasValue)
                {
                    if (statusCode == HttpStatusCode.ServiceUnavailable ||
                        statusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new ServiceUnavailableException("The Riot API is currently unavailable. Please try again later.");
                    }

                    if (statusCode == (HttpStatusCode) 429)
                    {
                        string retryAfterHeader = ex.Response.Headers["Retry-After"];

                        int retryAfter = int.Parse(retryAfterHeader);

                        Thread.Sleep(retryAfter * 1000);

                        return retryFunc();
                    }
                }

                throw;
            }

        }
    }
}

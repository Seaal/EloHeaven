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
using Microsoft.Azure;

namespace EloHeaven.Logic.LeagueApi
{
    public class LeagueRequestService : ILeagueRequestService
    {
        private readonly IJsonClient _jsonClient;

        private readonly string _riotApi = ".api.pvp.net/api/lol/";

        public LeagueRequestService(IJsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public SummonerDTO GetSummoner(string region, string summonerName)
        {
            string resource = GetLeagueResourceUri(region, "v1.4/summoner/by-name/" + summonerName);

            SummonerDTO summonerDto = Get(resource, () => GetSummoner(region, summonerName));

            if (summonerDto == null)
            {
                throw new DataNotFoundException("Player could not be found");
            }

            return summonerDto;
        }

        public IEnumerable<LeagueDTO> GetLeagues(string region, long summonerId)
        {
            string resource = GetLeagueResourceUri(region, "v2.5/league/by-summoner/" + summonerId + "/entry");

            return Get(resource, () => GetLeagues(region, summonerId));
        }

        public RunepagesDTO GetRunepages(string region, long summonerId)
        {
            string resource = GetLeagueResourceUri(region, "v1.4/summoner/" + summonerId + "/runes");

            return Get(resource, () => GetRunepages(region, summonerId));
        }

        private string GetLeagueResourceUri(string region, string resource)
        {
            string apiKeyDelimiter = resource.Contains('?') ? "&api_key=" : "?api_key=";
            return "https://" + region.ToLowerInvariant() + _riotApi + region.ToLowerInvariant() + "/" + resource + apiKeyDelimiter + CloudConfigurationManager.GetSetting("RiotApiKey");
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

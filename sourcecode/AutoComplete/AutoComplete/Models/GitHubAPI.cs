using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using RestSharp;

namespace AutoComplete.Models
{
    public class GitHubAPI
    {
        private readonly string _token;
        private readonly string _baseurl;

        public GitHubAPI()
        {
            _token = "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";
            _baseurl = "https://api.github.com";
        }


        public SearchResultModel SearchIssues(List<string> keywords)
        {
            if (keywords != null && keywords.Count > 0)
            {
                var route = $"/search/topics?q={keywords.Aggregate((x, y) => x + " " + y)}";
                var response = RestGET(route);
                if (string.IsNullOrWhiteSpace(response))
                    return new SearchResultModel();
                else
                {
                    try
                    {
                        var result = JsonSerializer.Deserialize<SearchResultModel>(response);
                        return result ?? new SearchResultModel();
                    }
                    catch (Exception)
                    {
                        // log error
                        // throw exception
                    }
                }
            }
            else
            {
                // log no keywords supplied
            }

            return new SearchResultModel();
        }

        private string RestGET(string route)
        {
            string result = string.Empty;
            using (var client = new RestClient(_baseurl))
            {
                var request = new RestRequest(route, Method.Get);
                request.AddHeader("Authorization", "Bearer " + _token);
                request.AddHeader("Accept", "application/vnd.github+json");
                try
                {
                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        result = response.Content ?? string.Empty;
                    }
                    else
                    {
                        // log error
                        // throw exception
                    }
                }
                catch (Exception) { 
                    // log error
                    // throw exception
                }

                return result;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Portfolio.Models
{
    public class GitHub
    {
        public static async Task<List<Project>> GetProjects(int count)
        {
            string userName = "bizzclaw"; // temp until I can save it to pageInfo.

            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/search/repositories", Method.GET)
                .AddHeader("Accept", "application/vnd.github.v3+json")
                .AddHeader("User-Agent", userName)
                .AddParameter("q", $"user:{userName} fork:true")
                .AddParameter("order", "desc")
                .AddParameter("sort", "stars");
            var response = await GetResponseContentAsync(client, request) as RestResponse;

            JObject resultJSON = JsonConvert.DeserializeObject<JObject>(response.Content);
            IQueryable<Project> projectsJSON = JsonConvert.DeserializeObject<List<Project>>(resultJSON["items"].ToString()).AsQueryable();

            return projectsJSON.Take(count).ToList();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient client, IRestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}

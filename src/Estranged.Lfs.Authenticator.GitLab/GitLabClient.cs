using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal sealed class GitLabClient : IGitLabClient
    {
        private readonly HttpClient httpClient;

        public GitLabClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

       // this could be removed?
       public async Task<string> GetRepositoryPermissions(string organisation, string repository, CancellationToken token)
        {
            var response = await httpClient.GetAsync($"/2.0/user/permissions/repositories?q=repository.full_name=\"{HttpUtility.UrlEncode(organisation)}/{HttpUtility.UrlEncode(repository)}\"", token);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> GetRepository(string organisation, string repository, CancellationToken token)
        {
            // var response = await httpClient.GetAsync($"/v4/projects/{HttpUtility.UrlEncode(organisation)}/{HttpUtility.UrlEncode(repository)}", token);

            // next try, this actually works, add token and ID with config
            var request = new HttpRequestMessage(new HttpMethod("GET"), "https://gitlab.com/api/v4/projects/48255045");
            request.Headers.TryAddWithoutValidation("PRIVATE-TOKEN", "token"); 
            var response = await httpClient.SendAsync(request);

            // var response = await httpClient.GetAsync($"/projects/48255045", token);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}

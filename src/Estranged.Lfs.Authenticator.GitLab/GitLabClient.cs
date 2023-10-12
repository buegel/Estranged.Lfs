using System.Net.Http;
using System.Text.Json;
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

        public async Task<string> GetRepository(string access_token, string repository, CancellationToken token)
        {
            // Create request, maybe move base address to authenticator config
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://gitlab.com/api/v4/projects/{HttpUtility.UrlEncode(repository)}");
            request.Headers.TryAddWithoutValidation("PRIVATE-TOKEN", access_token); 
            
            // Send request
            var response = await httpClient.SendAsync(request);
            
            // Check if request was successful
            response.EnsureSuccessStatusCode();

            // Extract and return repository name, maybe create repository object as in bitbucket authentication
            var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            return doc.RootElement.GetProperty("name").GetString();
        }
    }
}

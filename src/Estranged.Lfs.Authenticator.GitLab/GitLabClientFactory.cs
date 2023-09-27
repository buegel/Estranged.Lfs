using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal sealed class GitLabClientFactory : IGitLabClientFactory
    {
        public IGitLabClient CreateClient(Uri baseAddress, string username, string password)
        {
            var client = new HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
            return new GitLabClient(client);
        }
    }
}

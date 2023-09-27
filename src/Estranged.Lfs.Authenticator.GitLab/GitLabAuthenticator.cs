using Estranged.Lfs.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal sealed class GitLabAuthenticator : IAuthenticator
    {
        private readonly IGitLabAuthenticatorConfig config;
        private readonly IGitLabClientFactory clientFactory;

        public GitLabAuthenticator(IGitLabAuthenticatorConfig config, IGitLabClientFactory clientFactory)
        {
            this.config = config;
            this.clientFactory = clientFactory;
        }

        public async Task Authenticate(string username, string password, LfsPermission requiredPermission, CancellationToken token)
        {
            var client = clientFactory.CreateClient(config.BaseAddress, username, password);

            // Check that the user can access the repository
            await client.GetRepository(config.Organisation, config.Repository, token);
        }
    }
}

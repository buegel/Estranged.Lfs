using Estranged.Lfs.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Estranged.Lfs.Authenticator.GitLab
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLfsGitLabAuthenticator(this IServiceCollection services, IGitLabAuthenticatorConfig config)
        {
            return services.AddSingleton<IAuthenticator, GitLabAuthenticator>()
                           .AddSingleton<IGitLabClientFactory, GitLabClientFactory>()
                           .AddSingleton(config);
        }
    }
}

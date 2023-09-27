using System.Threading;
using System.Threading.Tasks;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal interface IGitLabClient
    {
        Task<string> GetRepository(string organisation, string repository, CancellationToken token);
        Task<string> GetRepositoryPermissions(string organisation, string repository, CancellationToken token);
    }
}
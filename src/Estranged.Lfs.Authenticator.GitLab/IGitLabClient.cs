using System.Threading;
using System.Threading.Tasks;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal interface IGitLabClient
    {
        Task<string> GetRepository(string access_token, string repository, CancellationToken token);
    }
}
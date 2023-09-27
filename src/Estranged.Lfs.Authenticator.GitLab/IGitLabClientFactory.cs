using System;

namespace Estranged.Lfs.Authenticator.GitLab
{
    internal interface IGitLabClientFactory
    {
        IGitLabClient CreateClient(Uri baseAddress, string username, string password);
    }
}
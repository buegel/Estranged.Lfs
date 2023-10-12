using System;

namespace Estranged.Lfs.Authenticator.GitLab
{
    public interface IGitLabAuthenticatorConfig
    {
        Uri BaseAddress { get; }
        string AccessToken { get; }
        string Repository { get; }
    }
}

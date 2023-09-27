using System;

namespace Estranged.Lfs.Authenticator.GitLab
{
    public interface IGitLabAuthenticatorConfig
    {
        Uri BaseAddress { get; }
        string Organisation { get; }
        string Repository { get; }
    }
}

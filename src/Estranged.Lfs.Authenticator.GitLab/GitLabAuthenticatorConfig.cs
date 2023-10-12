using System;

namespace Estranged.Lfs.Authenticator.GitLab
{
    public sealed class GitLabAuthenticatorConfig : IGitLabAuthenticatorConfig
    {
        public Uri BaseAddress { get; set; } = new Uri("https://gitlab.com/api/v4/");
        public string AccessToken { get; set; }
        public string Repository { get; set; }
    }
}

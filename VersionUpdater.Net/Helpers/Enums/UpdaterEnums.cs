namespace VersionUpdater.Net.Helpers.Enums
{
    /// <summary>
    /// Enum for github authentication type
    /// </summary>
    public enum GithubAuthenticationType
    {
        /// <summary>
        /// Without authorization (For public repositories).
        /// </summary>
        Anonymous,

        /// <summary>
        /// Authentication type is bearer (Personal access token).
        /// </summary>
        Bearer
    }
}

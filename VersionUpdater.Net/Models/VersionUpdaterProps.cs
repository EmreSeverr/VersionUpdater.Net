using System;
using VersionUpdater.Net.Helpers.Enums;

namespace VersionUpdater.Net.Models
{
    /// <summary>
    /// Requirement properties for VersionUpdater.Net.
    /// </summary>
    public class VersionUpdaterProps
    {
        /// <summary>
        /// Repository name.
        /// </summary>
        public string RepositoryName { get; set; }

        /// <summary>
        /// Owner name.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Github token.
        /// 
        /// <para> If your repository is private. You must set this property. </para>
        /// 
        /// </summary>
        public string GithubToken {  get; set; }

        /// <summary>
        /// Github authentication type.
        /// </summary>
        public GithubAuthenticationType GithubAuthenticationType { get; set; }

        /// <summary>
        /// Current version.
        /// </summary>
        internal Version Version { get; set; }
    }
}

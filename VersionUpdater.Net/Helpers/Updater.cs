using Octokit;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using VersionUpdater.Net.Helpers.Enums;
using VersionUpdater.Net.Models;
using VersionUpdater.Net.Services.Abstract;
using VersionUpdater.Net.Services.Concrate;

namespace VersionUpdater.Net.Helpers
{
    /// <summary>
    /// Extensions class for VersionUpdater.Net
    /// </summary>
    public static class Updater
    {
        /// <summary>
        /// Configures VersionUpdater.Net.
        /// </summary>
        /// <param name="updaterConAction"></param>
        /// <returns></returns>
        public static async Task ApplyVersionUpdaterAsync(Action<VersionUpdaterProps> updaterConAction)
        {
            VersionUpdaterProps updaterCon = new();

            updaterConAction.Invoke(updaterCon);

            updaterCon.Version = Version.Parse(System.Windows.Forms.Application.ProductVersion);

            if (CheckNetworkConnection())
            {
                IVersionService versionService = new VersionService(updaterCon);
                await versionService.CheckHaveUpdateAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides information about whether the device is connected to the internet.
        /// </summary>
        /// <returns></returns>
        public static bool CheckNetworkConnection()
        {
            try
            {
                TcpClient tcpClient = new TcpClient("www.google.com.tr", 80);
                tcpClient.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Extensions

        /// <summary>
        /// Returns authentication type for octakit.
        /// </summary>
        /// <param name="githubAuthenticationType"></param>
        /// <returns></returns>
        internal static AuthenticationType GetAuthenticationType(this GithubAuthenticationType githubAuthenticationType)
        {
            switch (githubAuthenticationType)
            {
                case GithubAuthenticationType.Anonymous:
                    return AuthenticationType.Anonymous;
                case GithubAuthenticationType.Bearer:
                    return AuthenticationType.Bearer;
                default:
                    return AuthenticationType.Anonymous;
            }
        }

        #endregion
    }
}

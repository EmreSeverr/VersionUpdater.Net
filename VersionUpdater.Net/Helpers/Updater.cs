using Octokit;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using VersionUpdater.Net.Helpers.CronJob;
using VersionUpdater.Net.Helpers.CronJob.Models.Abstract;
using VersionUpdater.Net.Helpers.Enums;
using VersionUpdater.Net.Helpers.Exceptions;
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
        public static async Task<List<string>> ApplyVersionUpdaterAsync(Action<VersionUpdaterProps> updaterConAction)
        {
            VersionUpdaterProps updaterCon = new();

            updaterConAction.Invoke(updaterCon);

            updaterCon.Version = Version.Parse(System.Windows.Forms.Application.ProductVersion);

            List<string> updateNotes = new();

            if (CheckNetworkConnection())
            {
                IVersionService versionService = new VersionService(updaterCon);
                updateNotes = await versionService.CheckHaveUpdateAsync().ConfigureAwait(false);

                if (updaterCon.ScheduleConfig != null)
                {
                    updaterCon.ScheduleConfig.CheckCronJobParameters();

                    CronJobUpdate cronJobUpdate = new(updaterCon.ScheduleConfig, versionService.CheckHaveUpdateAsync);

                    await cronJobUpdate.StartAsync(new CancellationToken()).ConfigureAwait(false);
                }
            }

            return updateNotes;
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

        /// <summary>
        /// checks whether <see cref="IScheduleConfig.CronExpression"/> is valid.
        /// </summary>
        /// <param name="scheduleConfig"></param>
        private static void CheckCronJobParameters(this IScheduleConfig scheduleConfig)
        {
            if (string.IsNullOrWhiteSpace(scheduleConfig.CronExpression))
                throw new UpdaterException("Empty Cron Expression is not allowed.");
        }

        #endregion
    }
}

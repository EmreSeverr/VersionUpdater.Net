using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionUpdater.Net.Helpers;
using VersionUpdater.Net.Helpers.Enums;
using VersionUpdater.Net.Helpers.Exceptions;
using VersionUpdater.Net.Helpers.Forms;
using VersionUpdater.Net.Helpers.Forms.Loader;
using VersionUpdater.Net.Models;
using VersionUpdater.Net.Services.Abstract;

namespace VersionUpdater.Net.Services.Concrate
{
    /// <summary>
    /// Class of version service.
    /// </summary>
    internal class VersionService : IVersionService
    {
        private UpdateMessageForm? _updateMessageForm;
        private ReleaseAsset? _latestRelease;
        private bool _updateRequirement;
        private readonly string _startupPath;
        private readonly string _zipFileName;
        private readonly VersionUpdaterProps _updaterCon;

        /// <summary>
        /// Constructor of <see cref="VersionService"/>.
        /// </summary>
        /// <param name="updaterCon"></param>
        public VersionService(VersionUpdaterProps updaterCon)
        {
            _updaterCon = updaterCon;
            _startupPath = System.Windows.Forms.Application.StartupPath;
            _zipFileName = "newRelease.zip";
        }

        /// <summary>
        /// Checks for new updates.
        /// </summary>
        /// <returns></returns>
        public async Task CheckHaveUpdateAsync()
        {
            var client = new GitHubClient(new ProductHeaderValue(_updaterCon.RepositoryName));

            if (_updaterCon.GithubAuthenticationType != GithubAuthenticationType.Anonymous)
            {
                var tokenAuth = new Credentials(_updaterCon.GithubToken, authenticationType: _updaterCon.GithubAuthenticationType.GetAuthenticationType());
                client.Credentials = tokenAuth;
            }

            var releases = await client.Repository.Release.GetAll(_updaterCon.Owner, _updaterCon.RepositoryName).ConfigureAwait(false);

            (Version githubVersion, bool updateRequirement, ReleaseAsset latestRelease) = GetVersionAndUpdateRequirement(releases);

            _latestRelease = latestRelease;
            _updateRequirement = updateRequirement;

            if (githubVersion > _updaterCon.Version)
            {
                _updateMessageForm = new();
                _updateMessageForm.buttonUpdateLater.Click += new EventHandler(LaterUpdateApplication);
                _updateMessageForm.buttonUpdate.Click += new EventHandler(UpdateApplication);

                if (updateRequirement)
                    _updateMessageForm.buttonUpdateLater.Visible = false;

                _updateMessageForm.ShowDialog();
            }
        }

        #region Helper Methods

        /// <summary>
        /// Restart application.
        /// </summary>
        private static void RestartApplication() => System.Windows.Forms.Application.Restart();

        /// <summary>
        /// Updates application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateApplication(object? sender, EventArgs e)
        {
            LoadingFunction loadingFunction = new();

            loadingFunction.Show();

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Anything");

                    if (!string.IsNullOrEmpty(_updaterCon.GithubToken))
                        client.Headers.Add("Authorization", "Bearer " + _updaterCon.GithubToken);

                    client.Headers.Add("Accept", "application/octet-stream");
                    client.DownloadFile(_latestRelease?.Url ?? throw new UpdaterException("Cannot find release url."), _zipFileName);
                }

                DeleteBakFiles();

                FileMove(Directory.GetFiles(@"."));

                var zipFileDirectory = Path.Combine(_startupPath, _zipFileName);

                ZipFile.ExtractToDirectory(zipFileDirectory, @".", true);

                loadingFunction.Close();

                RestartApplication();
            }
            catch (Exception exception)
            {
                loadingFunction.Close();

                MessageBox.Show(exception.ToString());
            }

            _updateMessageForm?.Close();
        }

        /// <summary>
        /// Files moves for update operation.
        /// </summary>
        /// <param name="fileEntries"></param>
        private static void FileMove(string[] fileEntries)
        {
            var otherFiles = fileEntries.Where(p => !p.Contains(".bak") && !p.Contains(".zip")).ToList();

            foreach (var filePath in otherFiles)
            {
                string newFiles = @$".\{Path.GetFileName(filePath)}.bak";

                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath)) { }
                }

                File.Move(filePath, newFiles, true);
            }
        }

        /// <summary>
        /// Later update function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaterUpdateApplication(object? sender, EventArgs e) => _updateMessageForm?.Close();

        /// <summary>
        /// Delete downloading zip file.
        /// </summary>
        private void DeleteZipFile()
        {
            foreach (var file in Directory.GetFiles(_startupPath).Where(p => p.Contains(_zipFileName)))
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
        }

        /// <summary>
        /// Deletes bak files.
        /// </summary>
        private void DeleteBakFiles()
        {
            foreach (var bakFile in Directory.GetFiles(_startupPath).Where(p => p.Contains(".bak")))
            {
                File.SetAttributes(bakFile, FileAttributes.Normal);
                File.Delete(bakFile);
            }
        }

        /// <summary>
        /// Find github version, update requirement and latest.
        /// </summary>
        /// <param name="releases"></param>
        /// <returns></returns>
        private (Version githubVersion, bool updateRequirement, ReleaseAsset latest) GetVersionAndUpdateRequirement(IReadOnlyList<Release?> releases)
        {
            var release = releases[0] ?? throw new UpdaterException("Not found any release.");

            var tagAndUpdateRequirement = release.TagName.Split("-");

            return (Version.Parse(tagAndUpdateRequirement[0]), bool.Parse(tagAndUpdateRequirement[1]), release.Assets[0]);
        }

        #endregion
    }
}

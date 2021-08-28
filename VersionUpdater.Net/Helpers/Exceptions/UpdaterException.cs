using System;

namespace VersionUpdater.Net.Helpers.Exceptions
{
    /// <summary>
    /// Exception class for updater.
    /// </summary>
    public class UpdaterException : Exception
    {
        /// <summary>
        /// Constructor of <see cref="UpdaterException"/>.
        /// </summary>
        /// <param name="message"></param>
        public UpdaterException(string message) : base(message)
        {
        }
    }
}

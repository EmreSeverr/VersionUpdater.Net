﻿using System.Threading.Tasks;

namespace VersionUpdater.Net.Services.Abstract
{
    /// <summary>
    /// Class of version service.
    /// </summary>
    public interface IVersionService
    {
        /// <summary>
        /// Checks for new updates.
        /// </summary>
        /// <returns></returns>
        Task CheckHaveUpdateAsync();
    }
}
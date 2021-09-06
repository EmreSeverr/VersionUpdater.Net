using System.Collections.Generic;
using System.Threading.Tasks;

namespace VersionUpdater.Net.Services.Abstract
{
    /// <summary>
    /// Class of version service.
    /// </summary>
    internal interface IVersionService
    {
        /// <summary>
        /// Checks for new updates.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> CheckHaveUpdateAsync();
    }
}
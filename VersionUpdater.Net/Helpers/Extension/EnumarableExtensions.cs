using System.Collections;

namespace VersionUpdater.Net.Helpers.Extension
{
    /// <summary>
    /// Extension class of enumarable
    /// </summary>
    public static class EnumarableExtensions
    {
        /// <summary>
        /// Checks whether or not collection is null or empty. Assumes collection can be safely enumerated multiple times.
        /// </summary>
        public static bool IsNullOrEmpty(this IEnumerable @this) => @this == null || @this.GetEnumerator().MoveNext() == false;
    }
}

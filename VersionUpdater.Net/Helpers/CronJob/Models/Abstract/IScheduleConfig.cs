using System;

namespace VersionUpdater.Net.Helpers.CronJob.Models.Abstract
{
    /// <summary>
    /// Cron job settings.
    /// </summary>
    public interface IScheduleConfig
    {
        /// <summary>
        /// Cron expression
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// Time zone.
        /// </summary>
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}

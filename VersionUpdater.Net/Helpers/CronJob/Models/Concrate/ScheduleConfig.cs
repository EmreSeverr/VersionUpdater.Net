using System;
using VersionUpdater.Net.Helpers.CronJob.Models.Abstract;

namespace VersionUpdater.Net.Helpers.CronJob.Models.Concrate
{
    /// <summary>
    /// Cron job settings
    /// </summary>
    public class ScheduleConfig : IScheduleConfig
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

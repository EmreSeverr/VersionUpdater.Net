using System;
using System.Threading;
using System.Threading.Tasks;
using VersionUpdater.Net.Helpers.CronJob.Models.Abstract;

namespace VersionUpdater.Net.Helpers.CronJob
{
    /// <summary>
    /// Cron job configuration class
    /// </summary>
    internal class CronJobUpdate : CronJobService
    {
        private readonly Func<Task> _func;

        /// <summary>
        /// Constuructor of <see cref="CronJobUpdate"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="func"></param>
        internal CronJobUpdate(IScheduleConfig config, Func<Task> func) : base(config.CronExpression, config.TimeZoneInfo) => _func = func;

        /// <summary>
        /// It starts the job.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StartAsync(CancellationToken cancellationToken) => base.StartAsync(cancellationToken);

        /// <summary>
        /// It stops the job.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StopAsync(CancellationToken cancellationToken) => base.StopAsync(cancellationToken);

        /// <summary>
        /// Triggers the method that will be executed acacording to cron expression.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoWorkAsync(CancellationToken cancellationToken) => await _func.Invoke().ConfigureAwait(false);
    }
}

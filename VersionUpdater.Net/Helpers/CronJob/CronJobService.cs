using Cronos;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VersionUpdater.Net.Helpers.CronJob
{
    /// <summary>
    /// Cron job configuration class
    /// </summary>
    internal class CronJobService : IHostedService, IDisposable
    {
        private System.Timers.Timer _timer;
        private readonly CronExpression _expression;
        private readonly TimeZoneInfo _timeZoneInfo;

        /// <summary>
        /// Constructor of <see cref="CronJobService"/>.
        /// </summary>
        /// <param name="cronExpression"></param>
        /// <param name="timeZoneInfo"></param>
        internal CronJobService(string cronExpression, TimeZoneInfo timeZoneInfo)
        {
            _expression = CronExpression.Parse(cronExpression);
            _timeZoneInfo = timeZoneInfo;
            _timer = new System.Timers.Timer();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => _timer?.Dispose();

        /// <summary>
        /// It starts the job.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task StartAsync(CancellationToken cancellationToken) => await ScheduleJobAsync(cancellationToken);

        /// <summary>
        /// A function that will be executed according to cron expression.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task DoWorkAsync(CancellationToken cancellationToken) => await Task.Delay(5000, cancellationToken);

        /// <summary>
        /// It stops the job.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Triggers the method that will be executed acacording to cron expression.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual async Task ScheduleJobAsync(CancellationToken cancellationToken)
        {
            var next = _expression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)   
                {
                    await ScheduleJobAsync(cancellationToken);
                }
                _timer = new System.Timers.Timer(delay.TotalMilliseconds);
                _timer.Elapsed += async (sender, args) =>
                {
                    _timer.Dispose();  
                    _timer = null;

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await DoWorkAsync(cancellationToken);
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await ScheduleJobAsync(cancellationToken);
                    }
                };
                _timer.Start();
            }
            await Task.CompletedTask;
        }
    }
}

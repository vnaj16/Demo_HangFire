using Hangfire;
using Microsoft.Extensions.Logging;
using System;

namespace Demo_HangFire
{
    public class VNAJBackgroundJobs : IBackgroundJobs
    {
        ILogger _logger;

        public VNAJBackgroundJobs(ILogger<VNAJBackgroundJobs> logger)
        {
            _logger = logger;
        }

        public void ContinuationJob()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Proceso 1, luego de que acabe debe seguir el proceso 2"));
            BackgroundJob.ContinueJobWith(
    jobId,
    () => Console.WriteLine("Proceso 2, ya terminó proceso 1, ahora debo seguir yo"));
        }

        public void DelayedJob()
        {
            _logger.LogInformation($"Job solicitado (DelayedJob)");
            var jobId = BackgroundJob.Schedule(
                () => Console.WriteLine("Hello From DelayedJob!"),
                TimeSpan.FromSeconds(10));
            _logger.LogInformation($"Job {jobId} lanzado (DelayedJob)");
        }

        public void FireAndForgetJob()
        {
            var param1 = "Hola, soy Arthur";
            var jobId = BackgroundJob.Enqueue(() => Method4FireAndForgetJob(param1));
            _logger.LogInformation($"Job {jobId} lanzado (FireAndForgetJob)");
        }

        public void Method4FireAndForgetJob(string param1)
        {
            System.Console.WriteLine($"Ejecucion desde FireAndForgetJob: {param1}");
            System.Console.WriteLine("Aca podria ir mas lógica que se ejecutará behind scenes");
        }

        public void ReccuringJob()
        {
            RecurringJob.AddOrUpdate(
                "myrecurringjob",
                () => Console.WriteLine("Recurring!"),
                Cron.Minutely);
        }
    }
}

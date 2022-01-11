namespace Demo_HangFire
{
    public interface IBackgroundJobs
    {
        void FireAndForgetJob();

        void ReccuringJob();

        void DelayedJob();

        void ContinuationJob();

    }
}

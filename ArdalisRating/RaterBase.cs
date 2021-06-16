using ArdalisRating.Interfaces;

namespace ArdalisRating
{
    public abstract class RaterBase
    {
        public ILogger Logger { get; set; }

        //public Rater(RatingEngine engine)
        //{
        //}

        public RaterBase(ILogger logger)
        {
            Logger = logger;
        }

        public abstract decimal Rate(Policy policy);


    }
}
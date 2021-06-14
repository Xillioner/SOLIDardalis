namespace ArdalisRating
{
    public abstract class Rater:Logger
    {
        public Rater(RatingEngine engine)
        {
        }

        public abstract void Rate(Policy policy);


    }
}
using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class RatingUpdater : IRatingUpdater
    {
        private RatingEngine engine;

        public void UpdateRating(decimal rating)
        {
            engine.Rating = rating;
        }
    }
}

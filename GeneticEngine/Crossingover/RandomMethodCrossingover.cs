using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class RandomMethodCrossingover : AbstractCrossingover, ICrossingover
    {
        public const string CrossingoverName = "RandomMethodCrossingover";

        private List<ICrossingover> _crossingoverList;
        public RandomMethodCrossingover(List<ICrossingover> crossingoverList)
        {
            _crossingoverList = new List<ICrossingover>();
            _crossingoverList = crossingoverList;
        }
        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChild)
        {
            Random random = new Random();
            int numberOfCrossingover = random.Next(_crossingoverList.Count());
            _crossingoverList[numberOfCrossingover].Crossingover(firstParent, secondParent, firstChild, secondChild);
        }

        public string GetName()
        {
            return CrossingoverName;
        }
    }
}

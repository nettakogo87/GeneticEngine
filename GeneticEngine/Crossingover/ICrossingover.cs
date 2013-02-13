using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public interface ICrossingover
    {
        void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild, AbstractTrack secondChaild);
        string GetName();
    }
}

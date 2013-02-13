using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public interface ICrossingover
    {
        void Crossingover(ITrack firstParent, ITrack secondParent, ITrack firstChild, ITrack secondChaild);
        string GetName();
    }
}

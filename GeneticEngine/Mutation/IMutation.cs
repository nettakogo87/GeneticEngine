using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public interface IMutation
    {
        void Mutation(ITrack mutant);
        string GetName();
    }
}

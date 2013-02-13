using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.FitnessFunction
{
    public interface IFitnessFunction
    {
        bool Fitness(ITrack[] tracks, IGraph graph);
        double BestResult { get; }
        int ActualCountOfReps { get; }
    }
}

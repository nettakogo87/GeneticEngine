using System;
using System.Linq;
using GeneticEngine.Graph;

namespace GeneticEngine.Track
{
    public class ClosedTrack : AbstractTrack
    {
        public ClosedTrack(int[] trackPoints) : base(trackPoints)
        {
        }
        public ClosedTrack(int countOfAllele, bool autofill) : base(countOfAllele, autofill)
        {
        }

        public override double GetTrackLength(IGraph graph)
        {
            double trackLength = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                trackLength += graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
            }
            trackLength += graph.GetWeightByRip(Genotype[0], Genotype[Genotype.Length - 1]);
            return trackLength;
        }

        public override AbstractTrack EmptyClone()
        {
            ClosedTrack track = new ClosedTrack(this.Genotype.Length, false);
            return (AbstractTrack)track;
        }
    }
}

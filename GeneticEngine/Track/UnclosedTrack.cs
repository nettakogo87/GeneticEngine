using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;


namespace GeneticEngine.Track
{
    public class UnclosedTrack : AbstractTrack
    {
        public UnclosedTrack(int[] trackPoints) : base(trackPoints)
        {
        }
        public UnclosedTrack(int countOfAllele, bool autofill) : base(countOfAllele, autofill)
        {
        }

        public override double GetTrackLength(IGraph graph)
        {
            double trackLength = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                trackLength += graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
            }
            return trackLength;
        }

        public override AbstractTrack EmptyClone()
        {
            UnclosedTrack track = new UnclosedTrack(this.Genotype.Length, false);
            return (AbstractTrack) track;
        }
    }
}

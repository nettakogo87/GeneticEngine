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

        public override Dictionary<int, int> GetWorstRip(IGraph graph)
        {
            double[,] rips = new double[Genotype.Length - 1, 3];
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                rips[i, 0] = graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
                rips[i, 1] = Genotype[i];
                rips[i, 2] = Genotype[i + 1];
            }
            double max = rips[0, 0];
            int j = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                if (max < rips[i, 0])
                {
                    max = rips[i, 0];
                    j = i;
                }
            }
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary.Add(0, Convert.ToInt32(rips[j, 1]));
            dictionary.Add(1, Convert.ToInt32(rips[j, 2]));
            return dictionary;
        }
        public override Dictionary<int, int> GetBestRip(IGraph graph)
        {
            double[,] rips = new double[Genotype.Length - 1, 3];
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                rips[i, 0] = graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
                rips[i, 1] = Genotype[i];
                rips[i, 2] = Genotype[i + 1];
            }
            double min = rips[0, 0];
            int j = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                if (min > rips[i, 0])
                {
                    min = rips[i, 0];
                    j = i;
                }
            }
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary.Add(0, Convert.ToInt32(rips[j, 1]));
            dictionary.Add(1, Convert.ToInt32(rips[j, 2]));
            return dictionary;
        }
    }
}

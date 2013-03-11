using System;
using System.Collections.Generic;
using System.Linq;
using GeneticEngine.Graph;

namespace GeneticEngine.Track
{
    public class ClosedTrack : AbstractTrack
    {
        public const string TypeOfTrack = "ClosedTrack";

        public ClosedTrack(int[] trackPoints, IGraph graph)
            : base(trackPoints, graph)
        {
        }
        public ClosedTrack(int countOfAllele,  IGraph graph, bool autofill) : base(countOfAllele, graph, autofill)
        {
        }

        public override double GetTrackLength()
        {
            double trackLength = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                trackLength += _graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
            }
            trackLength += _graph.GetWeightByRip(Genotype[0], Genotype[Genotype.Length - 1]);
            return trackLength;
        }

        public override AbstractTrack EmptyClone()
        {
            ClosedTrack track = new ClosedTrack(this.Genotype.Length, _graph, false);
            return (AbstractTrack)track;
        }
        public override AbstractTrack Clone()
        {
            ClosedTrack track = new ClosedTrack(this.Genotype, _graph);
            track.FirstParent = this.FirstParent;
            track.SecondParent = this.SecondParent;
            return (AbstractTrack)track;
        }

        public override int CompareTo(object obj)
        {
            AbstractTrack track = (AbstractTrack) obj;
            return this.GetTrackLength().CompareTo(track.GetTrackLength());
        }

        public override Dictionary<int, int> GetWorstRip()
        {
            double[,] rips = new double[Genotype.Length, 3];
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                rips[i, 0] = _graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
                rips[i, 1] = Genotype[i];
                rips[i, 2] = Genotype[i + 1];
            }
            rips[Genotype.Length - 1, 0] = _graph.GetWeightByRip(Genotype[0], Genotype[Genotype.Length - 1]);
            rips[Genotype.Length - 1, 1] = Genotype[0];
            rips[Genotype.Length - 1, 2] = Genotype[Genotype.Length - 1];
            double max = rips[0, 0];
            int j = 0;
            for (int i = 0; i < Genotype.Length; i++)
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
        public override Dictionary<int, int> GetBestRip()
        {
            double[,] rips = new double[Genotype.Length, 3];
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                rips[i, 0] = _graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
                rips[i, 1] = Genotype[i];
                rips[i, 2] = Genotype[i + 1];
            }
            rips[Genotype.Length - 1, 0] = _graph.GetWeightByRip(Genotype[0], Genotype[Genotype.Length - 1]);
            rips[Genotype.Length - 1, 1] = Genotype[0];
            rips[Genotype.Length - 1, 2] = Genotype[Genotype.Length - 1];
            double min = rips[0, 0];
            int j = 0;
            for (int i = 0; i < Genotype.Length; i++)
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

        public override string GetTypeOfTrack()
        {
            return TypeOfTrack;
        }
    }
}

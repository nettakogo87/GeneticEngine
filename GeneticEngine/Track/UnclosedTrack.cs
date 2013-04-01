using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;


namespace GeneticEngine.Track
{
    public class UnclosedTrack : AbstractTrack
    {
        public const string TypeOfTrack = "UnclosedTrack";

        public UnclosedTrack(int[] trackPoints, IGraph graph)
            : base(trackPoints, graph)
        {
        }
        public UnclosedTrack(int countOfAllele, IGraph graph, bool autofill)
            : base(countOfAllele, graph, autofill)
        {
        }

        public override int CompareTo(object obj)
        {
            AbstractTrack track = (AbstractTrack)obj;
            return this.GetTrackLength().CompareTo(track.GetTrackLength());
        }

        public override double GetTrackLength()
        {
            double trackLength = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                trackLength += _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]).Weight;
            }
            return trackLength;
        }

        public override AbstractTrack EmptyClone()
        {
            UnclosedTrack track = new UnclosedTrack(this.Genotype.Length, _graph, false);
            return (AbstractTrack) track;
        }
        public override AbstractTrack Clone()
        {
            UnclosedTrack track = new UnclosedTrack(this.Genotype, _graph);
            track.FirstParent = this.FirstParent;
            track.SecondParent = this.SecondParent;
            return (AbstractTrack)track;
        }

        public override Rib GetWorstRib()
        {
            Rib[] ribs = new Rib[Genotype.Length -1];
            for (int i = 0; i < ribs.Length; i++)
            {
                ribs[i] = _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]);
            }
            double max = ribs[0].Weight;
            int j = 0;
            for (int i = 0; i < ribs.Length; i++)
            {
                if (max < ribs[i].Weight)
                {
                    max = ribs[i].Weight;
                    j = i;
                }
            }
            return ribs[j];
        }
        public override Rib GetBestRib()
        {
            Rib[] ribs = new Rib[Genotype.Length - 1];
            for (int i = 0; i < ribs.Length; i++)
            {
                ribs[i] = _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]);
            }
            double min = ribs[0].Weight;
            int j = 0;
            for (int i = 0; i < ribs.Length; i++)
            {
                if (min > ribs[i].Weight)
                {
                    min = ribs[i].Weight;
                    j = i;
                }
            }
            return ribs[j];
        }

        public override string GetTypeOfTrack()
        {
            return TypeOfTrack;
        }

        public override string ToString()
        {
            string nodes = "";
            for (int i = 0; i < Genotype.Length; i++)
            {
                nodes += Genotype[i].ToString() + " ";
            }
            return nodes;
        }
    }
}

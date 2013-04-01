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
                trackLength += _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]).Weight;
            }
            trackLength += _graph.GetRibByNodes(Genotype[0], Genotype[Genotype.Length - 1]).Weight;
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

        public override Rib GetWorstRib()
        {
            Rib[] ribs = new Rib[Genotype.Length];
            for (int i = 0; i < ribs.Length - 1; i++)
            {
                ribs[i] = _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]);
            }
            ribs[ribs.Length - 1] = _graph.GetRibByNodes(Genotype[0], Genotype[Genotype.Length - 1]);
            double max = ribs[0].Weight;
            int j = 0;
            for (int i = 0; i < Genotype.Length; i++)
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
            Rib[] ribs = new Rib[Genotype.Length];
            for (int i = 0; i < ribs.Length - 1; i++)
            {
                ribs[i] = _graph.GetRibByNodes(Genotype[i], Genotype[i + 1]);
            }
            ribs[ribs.Length - 1] = _graph.GetRibByNodes(Genotype[0], Genotype[Genotype.Length - 1]);
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
            nodes += Genotype[0].ToString();
            return nodes;
        }
    }
}

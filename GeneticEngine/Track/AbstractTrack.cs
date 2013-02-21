using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;

namespace GeneticEngine.Track
{
    public abstract class AbstractTrack : IComparer
    {
        public const int AggregateOfGenotype = -1;

        protected AbstractTrack(int[] trackPoints, IGraph graph)
        {
            Genotype = new int[trackPoints.Length];
            trackPoints.CopyTo(Genotype, 0);
            _graph = graph;
            TypeOfCrossingover = "Not";
            TypeOfMutation = "Not";
            TypeOfSelection = "Not";
        }

        protected AbstractTrack(int countOfAllele, IGraph graph, bool autofill)
        {
            _graph = graph;
            Genotype = new int[countOfAllele];
            for (int i = 0; i < countOfAllele; i++)
            {
                Genotype[i] = AggregateOfGenotype;
            }
            TypeOfCrossingover = "Not";
            TypeOfMutation = "Not";
            TypeOfSelection = "Not";

            if (autofill)
            {
                Random randomChromosome = new Random();
                int newRandomChromosome = randomChromosome.Next(countOfAllele - 1);
                for (int i = 0; i < countOfAllele; i++)
                {
                    while (Genotype.Contains(newRandomChromosome))
                    {
                        newRandomChromosome = randomChromosome.Next(countOfAllele);
                    }
                    Genotype[i] = newRandomChromosome;
                }
            }
        }

        protected IGraph _graph;
        public int[] Genotype { get; set; }
        public string TypeOfSelection { get; set; }
        public string TypeOfMutation { get; set; }
        public string TypeOfCrossingover { get; set; }

        public abstract double GetTrackLength();
        public abstract Dictionary<int, int> GetWorstRip();
        public abstract Dictionary<int, int> GetBestRip();
        public abstract AbstractTrack EmptyClone();
        public abstract AbstractTrack Clone();

        public abstract int Compare(object x, object y);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;

namespace GeneticEngine.Track
{
    public abstract class AbstractTrack
    {
        public const int AggregateOfGenotype = -1;
        public abstract double GetTrackLength(IGraph graph);
        public abstract Dictionary<int, int> GetWorstRip(IGraph graph);
        public abstract Dictionary<int, int> GetBestRip(IGraph graph);

        protected AbstractTrack(int[] trackPoints)
        {
            Genotype = new int[trackPoints.Length];
            trackPoints.CopyTo(Genotype, 0);
        }

        public AbstractTrack(int countOfAllele, bool autofill)
        {
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

        public abstract AbstractTrack EmptyClone();
        public abstract AbstractTrack Clone();

        public int[] Genotype { get; set; }
        public string TypeOfSelection { get; set; }
        public string TypeOfMutation { get; set; }
        public string TypeOfCrossingover { get; set; }
    }
}

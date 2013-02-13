using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;


namespace GeneticEngine.Track
{
    public class UnclosedTrack : ITrack
    {
        public UnclosedTrack(int countOfAllele, bool autofill)
        {
            Genotype = new int[countOfAllele];
            for (int i = 0; i < countOfAllele; i++)
            {
                Genotype[i] = -1;
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

        public UnclosedTrack(int[] trackPoints)
        {
            Genotype = new int[trackPoints.Length];
            trackPoints.CopyTo(Genotype, 0);
        }

        public double GetTrackLength(IGraph graph)
        {
            double trackLength = 0;
            for (int i = 0; i < Genotype.Length - 1; i++)
            {
                trackLength += graph.GetWeightByRip(Genotype[i], Genotype[i + 1]);
            }
            return trackLength;
        }
        public string TypeOfTrack
        {
            get { return "UnclosedTrack"; }
        }

        public int[] Genotype { get; set; }
        public string TypeOfSelection { get; set; }
        public string TypeOfMutation { get; set; }
        public string TypeOfCrossingover { get; set; }
    }
}

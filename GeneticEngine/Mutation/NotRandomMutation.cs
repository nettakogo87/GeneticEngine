﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class NotRandomMutation : IMutation
    {
        private IGraph _graph;
        public NotRandomMutation(IGraph graph)
        {
            _graph = graph;
        }
        public void Mutation(AbstractTrack mutant)
        {
            int countOfAlleles = mutant.Genotype.Length;
            Dictionary<int, int> worstRip = mutant.GetWorstRip(_graph);
            DestroyBadRip(mutant, worstRip[0], worstRip[1]);

        }

        private static void DestroyBadRip(AbstractTrack mutant, int firstGen, int secondGen)
        {
            int countOfAlleles = mutant.Genotype.Length;
            for (int i = 0; i < countOfAlleles; i++)
            {
                if (mutant.Genotype[i] == firstGen)
                {
                    Random newRandom = new Random();
                    int newPoint = newRandom.Next(countOfAlleles);
                    while (mutant.Genotype[newPoint] == firstGen || mutant.Genotype[newPoint] == secondGen)
                    {
                        newPoint = newRandom.Next(countOfAlleles);
                    }
                    mutant.Genotype[i] = mutant.Genotype[newPoint];
                    mutant.Genotype[newPoint] = firstGen;
                    break;
                }
            }
        }

        public string GetName()
        {
            return "NotRandomMutation";
        }
    }
}
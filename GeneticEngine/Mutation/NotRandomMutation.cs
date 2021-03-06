﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class NotRandomMutation : AbstractMutation, IMutation
    {
        public const string MutationName = "NotRandomMutation";

        public void Mutation(AbstractTrack mutant)
        {
            Rib worstRib = mutant.GetWorstRib();
            DestroyBadRip(mutant, worstRib.StartNode, worstRib.EndNode);
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
                    mutant.TypeOfMutation = MutationName;
                    break;
                }
            }
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

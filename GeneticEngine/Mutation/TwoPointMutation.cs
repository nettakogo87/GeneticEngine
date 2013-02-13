﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class TwoPointMutation : IMutation
    {
        public void Mutation(ITrack mutant)
        {
            Random randomPosition = new Random();
            int firstPosition = randomPosition.Next(mutant.Genotype.Length - 1);
            int secondPosition = randomPosition.Next(mutant.Genotype.Length - 1);
            while (firstPosition == secondPosition)
            {
                secondPosition = randomPosition.Next(mutant.Genotype.Length - 1);
            }
            int chromosome = mutant.Genotype[secondPosition];
            mutant.Genotype[secondPosition] = mutant.Genotype[firstPosition];
            mutant.Genotype[firstPosition] = chromosome;
        }

        public string GetName()
        {
            return "TwoPointMutation";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class FourPointMutation : IMutation
    {
        public const string MutationName = "FourPointMutation";

        public void Mutation(AbstractTrack mutant)
        {
            int countOfAlleles = mutant.Genotype.Length;
            Random randomPosition = new Random();
            int firstPosition = randomPosition.Next(countOfAlleles);
            int secondPosition = randomPosition.Next(countOfAlleles);
            while (firstPosition == secondPosition)
            {
                secondPosition = randomPosition.Next(countOfAlleles);
            }
            int chromosome = mutant.Genotype[secondPosition];
            mutant.Genotype[secondPosition] = mutant.Genotype[firstPosition];
            mutant.Genotype[firstPosition] = chromosome;
            int thirdPosition = randomPosition.Next(countOfAlleles);
            while (thirdPosition == firstPosition || thirdPosition == secondPosition)
            {
                thirdPosition = randomPosition.Next(countOfAlleles);
            }
            int fourthPosition = randomPosition.Next(countOfAlleles);
            while (fourthPosition == firstPosition || fourthPosition == secondPosition || fourthPosition == thirdPosition)
            {
                fourthPosition = randomPosition.Next(countOfAlleles);
            }
            chromosome = mutant.Genotype[thirdPosition];
            mutant.Genotype[thirdPosition] = mutant.Genotype[fourthPosition];
            mutant.Genotype[fourthPosition] = chromosome;
            mutant.TypeOfSelection = MutationName;
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

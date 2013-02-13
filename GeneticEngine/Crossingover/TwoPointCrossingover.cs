using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class TwoPointCrossingover : ICrossingover
    {
        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChaild)
        {
            int countOfAlleles = firstParent.Genotype.Length;
            Random randomPositionOne = new Random();
            Random randomPositionTwo = new Random();
            int positionOne = randomPositionOne.Next(1, countOfAlleles - 1);
            int positionTwo = randomPositionTwo.Next(1, countOfAlleles - 1);
            while (positionOne == positionTwo)
            {
                positionTwo = randomPositionTwo.Next(1, countOfAlleles);
            }
            if (positionOne < positionTwo)
            {
                for (int i = positionOne; i <= positionTwo; i++)
                {
                    firstChild.Genotype[i] = firstParent.Genotype[i];
                    secondChaild.Genotype[i] = secondParent.Genotype[i];
                }
            }
            else
            {
                for (int i = positionTwo; i <= positionOne; i++)
                {
                    firstChild.Genotype[i] = firstParent.Genotype[i];
                    secondChaild.Genotype[i] = secondParent.Genotype[i];
                }
            }
            for (int i = 0; i < countOfAlleles; i++)
            {
                if (firstChild.Genotype[i] == AbstractTrack.AggregateOfGenotype)
                {
                    for (int j = 0; j < countOfAlleles; j++)
                    {
                        if (!firstChild.Genotype.Contains(secondParent.Genotype[j]))
                        {
                            firstChild.Genotype[i] = secondParent.Genotype[j];
                            break;
                        }
                    }
                    for (int j = 0; j < countOfAlleles; j++)
                    {
                        if (!secondChaild.Genotype.Contains(firstParent.Genotype[j]))
                        {
                            secondChaild.Genotype[i] = firstParent.Genotype[j];
                            break;
                        }
                    }
                }
            }
        }

        public string GetName()
        {
            return "TwoPointCrossingover";
        }
    }
}

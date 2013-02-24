using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class TwoPointCrossingover : AbstractCrossingover, ICrossingover
    {
        public const string CrossingoverName = "TwoPointCrossingover";

        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChild)
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
            if (positionOne > positionTwo)
            {
                int buff = positionOne;
                positionOne = positionTwo;
                positionTwo = buff;
            }
            for (int i = positionOne; i <= positionTwo; i++)
            {
                firstChild.Genotype[i] = firstParent.Genotype[i];
                secondChild.Genotype[i] = secondParent.Genotype[i];
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
                        if (!secondChild.Genotype.Contains(firstParent.Genotype[j]))
                        {
                            secondChild.Genotype[i] = firstParent.Genotype[j];
                            break;
                        }
                    }
                }
            }
            firstChild.TypeOfCrossingover = CrossingoverName;
            secondChild.TypeOfCrossingover = CrossingoverName;
        }

        public string GetName()
        {
            return CrossingoverName;
        }
    }
}

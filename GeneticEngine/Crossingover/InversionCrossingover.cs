using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class InversionCrossingover : ICrossingover
    {
        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChaild)
        {
            int countOfAlleles = firstParent.Genotype.Length;
            for (int i = 0; i < countOfAlleles; i++)
            {
                firstChild.Genotype[i] = firstParent.Genotype[i];
                secondChaild.Genotype[i] = secondParent.Genotype[i];
            }

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
            double delimetr = Math.Ceiling((Convert.ToDouble(positionOne + positionTwo)/2.0));
            for (int i = positionOne, j = positionTwo; i < delimetr; i++, j--)
            {
                int buff = firstChild.Genotype[i];
                firstChild.Genotype[i] = firstChild.Genotype[j];
                firstChild.Genotype[j] = buff;
                buff = secondChaild.Genotype[i];
                secondChaild.Genotype[i] = secondChaild.Genotype[j];
                secondChaild.Genotype[j] = buff;
            }
        }

        public string GetName()
        {
            return "InversionCrossingover";
        }
    }
}

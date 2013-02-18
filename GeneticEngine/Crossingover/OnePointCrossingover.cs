using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class OnePointCrossingover : ICrossingover
    {
        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild, AbstractTrack secondChild)
        {
            int countOfAlleles = firstParent.Genotype.Length;
            Random randomPosition = new Random();
            int position = randomPosition.Next(1, countOfAlleles);
            for (int i = 0; i < position; i++)
            {
                firstChild.Genotype[i] = firstParent.Genotype[i];
                secondChild.Genotype[i] = secondParent.Genotype[i];
            }
            for (int i = 0, j = position, k = position; i < countOfAlleles; i++)
            {
                if (!firstChild.Genotype.Contains(secondParent.Genotype[i]))
                {
                    firstChild.Genotype[j++] = secondParent.Genotype[i];
                }
                if (!secondChild.Genotype.Contains(firstParent.Genotype[i]))
                {
                    secondChild.Genotype[k++] = firstParent.Genotype[i];
                }
            }
        }

        public string GetName()
        {
            return "OnePointCrossingover";
        }
    }
}

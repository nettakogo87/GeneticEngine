using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class CyclicalCrossingover : AbstractCrossingover, ICrossingover
    {
        public const string CrossingoverName = "CyclicalCrossingover";

        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChild)
        {
            ChildrenFill(firstParent, secondParent, firstChild);
            ChildrenFill(secondParent, firstParent, secondChild);
        }

        private static void ChildrenFill(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack child)
        {
            int countOfAlleles = firstParent.Genotype.Length;
            int m = 0, n = countOfAlleles -1, k = 0, l = countOfAlleles - 1;
            while (child.Genotype.Contains(AbstractTrack.AggregateOfGenotype))
            {
                for (int i = m; i < countOfAlleles; i++)
                {
                    if (!child.Genotype.Contains(firstParent.Genotype[i]))
                    {
                        child.Genotype[k] = firstParent.Genotype[i];
                        k++;
                        m = i;
                        break;
                    }
                }
                for (int i = n; i > 0; i--)
                {
                    if (!child.Genotype.Contains(secondParent.Genotype[i]))
                    {
                        child.Genotype[l] = secondParent.Genotype[i];
                        l--;
                        n = i;
                        break;
                    }
                }
            }
            child.TypeOfCrossingover = CrossingoverName;
        }

        public string GetName()
        {
            return CrossingoverName;
        }
    }
}

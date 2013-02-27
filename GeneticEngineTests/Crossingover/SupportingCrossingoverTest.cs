using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngineTests.Crossingover
{
    public abstract class SupportingCrossingoverTest
    {
        protected const int CountOfAllele = 4;
        protected AbstractTrack _parent1;
        protected AbstractTrack _parent2;
        protected AbstractTrack _child1;
        protected AbstractTrack _child2;
        protected IGraph _graph;

        protected static bool NegativeNumber(int i)
        {
            if (i < 0)
            {
                return true;
            }
            return false;
        }

        protected bool TwoIntArrayEquals(int[] firstArray, int[] secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        protected bool IsItemsUnique(int[] mass)
        {
            for (int i = 0; i < mass.Length - 1; i++)
            {
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[i] == mass[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

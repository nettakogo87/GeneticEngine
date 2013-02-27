using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngineTests.Mutation
{
    public abstract class SupportingMutationTest
    {
        protected const int CountOfAllele = 4;
        protected AbstractTrack _mutant;
        protected IGraph _graph;
        protected AbstractTrack _subject;

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

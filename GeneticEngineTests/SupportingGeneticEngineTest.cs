using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngineTests
{
    public class SupportingGeneticEngineTest
    {
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
    }
}

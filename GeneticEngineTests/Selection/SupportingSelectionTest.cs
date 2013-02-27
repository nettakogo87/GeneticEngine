using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngineTests.Selection
{
    public abstract class SupportingSelectionTest
    {
        protected const int CountOfAllele = 4;
        protected const int CountOfTracks = 3;
        protected AbstractTrack[] _parents;
        protected AbstractTrack[] _childs;
        protected IGraph _graph;

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

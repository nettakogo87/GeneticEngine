using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticEngineTests.Track
{
    public abstract class SupportingTrackTest
    {
        protected const int CountOfAllele = 4;
        protected AbstractTrack _track;
        protected IGraph _graph;
        protected int[] _trackPoints = new int[] { 0, 2, 1, 3 };

        protected static bool NegativeNumber(int i)
        {
            if (i < 0)
            {
                return true;
            }
            return false;
        }
        protected static bool UpperLimitNumber(int i)
        {
            if (i >= CountOfAllele)
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
    }
}

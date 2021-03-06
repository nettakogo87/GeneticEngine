﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class RankingSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "RankingSelection";

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            int countOfTracks = parentTracks.Length;
            AbstractTrack[] allTracks = new AbstractTrack[countOfTracks * 2];
            for (int i = 0; i < countOfTracks; i++)
            {
                allTracks[i] = parentTracks[i].Clone();
                allTracks[i + countOfTracks] = childTracks[i].Clone();
            }
            Array.Sort(allTracks);
            for (int i = 0; i < countOfTracks; i++)
            {
                parentTracks[i] = allTracks[i];
                parentTracks[i].TypeOfSelection = SelectionName;
            }
        }

        public string GetName()
        {
            return SelectionName;
        }
    }
}

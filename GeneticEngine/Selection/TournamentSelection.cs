﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class TournamentSelection : ISelection
    {
        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks, IGraph graph)
        {
            for (int i = 0; i < parentTracks.Length; i++)
            {
                if (parentTracks[i].GetTrackLength(graph) > childTracks[i].GetTrackLength(graph))
                {
                    parentTracks[i] = childTracks[i];
                }
            }
        }

        public string GetName()
        {
            return "TournamentSelection Selection";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class Tournament : ISelection
    {
        public void Selection(ITrack[] parentTracks, ITrack[] childTracks, IGraph graph)
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
            return "Tournament Selection";
        }
    }
}

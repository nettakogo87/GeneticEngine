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
        public void Selection(AbstractTrack[] parentAbstractTracks, AbstractTrack[] childAbstractTracks, IGraph graph)
        {
            for (int i = 0; i < parentAbstractTracks.Length; i++)
            {
                if (parentAbstractTracks[i].GetTrackLength(graph) > childAbstractTracks[i].GetTrackLength(graph))
                {
                    parentAbstractTracks[i] = childAbstractTracks[i];
                }
            }
        }

        public string GetName()
        {
            return "Tournament Selection";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class TournamentSelection : ISelection
    {
        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            for (int i = 0; i < parentTracks.Length; i++)
            {
                if (parentTracks[i].GetTrackLength() > childTracks[i].GetTrackLength())
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

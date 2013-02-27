using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class TournamentSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "TournamentSelection";

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            for (int i = 0; i < parentTracks.Length; i++)
            {
                if (parentTracks[i].GetTrackLength() > childTracks[i].GetTrackLength())
                {
                    parentTracks[i] = childTracks[i];
                }
                parentTracks[i].TypeOfSelection = SelectionName;
            }
        }

        public string GetName()
        {
            return SelectionName;
        }
    }
}

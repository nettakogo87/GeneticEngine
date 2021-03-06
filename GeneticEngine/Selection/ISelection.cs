﻿using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public interface ISelection
    {
        void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks);
        string GetName();
    }
}

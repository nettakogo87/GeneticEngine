using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class Roulette : ISelection
    {
        private string _name;

        public Roulette()
        {
            _name = "Roulette";
        }

        public void Selection(ITrack[] parentTracks, ITrack[] childTracks, IGraph graph)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return _name;
        }

    }
}

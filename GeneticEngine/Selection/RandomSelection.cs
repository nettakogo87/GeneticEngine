using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class RandomSelection : ISelection
    {
        private string _name;
        private List<ISelection> _selectionList;

        public RandomSelection()
        {
            _name = "RandomSelection";
            _selectionList = new List<ISelection>();
            _selectionList.Add(new RouletteSelection());
            _selectionList.Add(new TournamentSelection());
        }

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks, IGraph graph)
        {

//            _selectionList.ElementAt(1).Selection();
            
        }

        public string GetName()
        {
            return _name;
        }
    }
}

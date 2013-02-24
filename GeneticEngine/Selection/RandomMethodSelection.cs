using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class RandomMethodSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "RandomMethodSelection";
        private List<ISelection> _selectionList;

        public RandomMethodSelection(List<ISelection> selectionList)
        {
            _selectionList = new List<ISelection>();
            _selectionList = selectionList;
        }

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            Random random = new Random();
            int numberOfSelection = random.Next(_selectionList.Count());
            _selectionList[numberOfSelection].Selection(parentTracks, childTracks);
        }

        public string GetName()
        {
            return SelectionName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class QualityCountsSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "QualityCountsSelection";
        private List<ProxySelection> _proxySelectionList;
        private int _index; // mutation algorithm Index

        public QualityCountsSelection(List<ProxySelection> proxySelectionList)
        {
            _proxySelectionList = new List<ProxySelection>();
            _proxySelectionList = proxySelectionList;
            _index = 0;
        }

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            if (_index == _proxySelectionList.Count)
            {
                _index = 0;
            }

            int countOfTracks = parentTracks.Length;
            AbstractTrack[] allTracks = new AbstractTrack[parentTracks.Length * 2];
            for (int i = 0; i < countOfTracks; i++)
            {
                allTracks[i] = parentTracks[i].Clone();
                allTracks[i + countOfTracks] = childTracks[i].Clone();
            }
            Array.Sort(allTracks);
            double currentResult = allTracks[0].GetTrackLength();

            DateTime startTime = DateTime.Now;
            _proxySelectionList[_index].GetSelection().Selection(parentTracks, childTracks);
            DateTime endTime = DateTime.Now;
            TimeSpan time = endTime - startTime;
            _proxySelectionList[_index].AddOperationTime(time);

            AbstractTrack[] newParentTracks = new AbstractTrack[parentTracks.Length];
            for (int i = 0; i < countOfTracks; i++)
            {
                newParentTracks[i] = parentTracks[i].Clone();
            }
            Array.Sort(newParentTracks);
            double sumOfParentTracks = newParentTracks.Sum(track => track.GetTrackLength());
            double newResult = newParentTracks[0].GetTrackLength();
            double sumOfBestResult = newResult * newParentTracks.Length;
            if ((0 == newResult.CompareTo(currentResult)) && (0 != sumOfParentTracks.CompareTo(sumOfBestResult)))
            {
                _proxySelectionList[_index].AddGoodStart();
            }
            else
            {
                _proxySelectionList[_index].AddBadStart();
            }
            _index++;
        }

        public string GetName()
        {
            return SelectionName;
        }
    }
}

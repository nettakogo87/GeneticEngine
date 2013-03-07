using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class SearchBestSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "SearchBestSelection";
        private List<ProxySelection> _proxySelectionList;
        private Random _random;

        public SearchBestSelection(List<ProxySelection> proxySelectionList)
        {
            _proxySelectionList = new List<ProxySelection>();
            _proxySelectionList = proxySelectionList;
            _random = new Random();
        }

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            double sumOfProgress = _proxySelectionList.Sum(proxySelection => proxySelection.GetProgress());
            double[] sectorsOfWheel = new double[_proxySelectionList.Count];
            for (int i = 0; i < _proxySelectionList.Count; i++)
            {
                sectorsOfWheel[i] = _proxySelectionList[i].GetProgress() / sumOfProgress * 100; // формула для поиска размера сектров колеса рулетки
            }

            int fallenSector = _random.Next(100);
            double sum = 0;
            for (int j = 0; j < sectorsOfWheel.Length; j++)
            {
                sum += sectorsOfWheel[j];
                if (sum > fallenSector)
                {
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
                    _proxySelectionList[j].GetSelection().Selection(parentTracks, childTracks);
                    DateTime endTime = DateTime.Now;
                    TimeSpan time = endTime - startTime;
                    _proxySelectionList[j].AddOperationTime(time);

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
                        _proxySelectionList[j].AddGoodStart();
                    }
                    else
                    {
                        _proxySelectionList[j].AddBadStart();
                    }
                    break;
                }
            }
        }

        public string GetName()
        {
            return SelectionName;
        }
    }
}

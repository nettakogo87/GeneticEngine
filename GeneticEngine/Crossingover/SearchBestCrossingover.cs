using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class SearchBestCrossingover : AbstractCrossingover, ICrossingover
    {
        public const string CrossingoverName = "SearchBestCrossingover";
        private List<ProxyCrossingover> _proxyCrossingoverList;
        private Random _random;

        public SearchBestCrossingover(List<ProxyCrossingover> proxyCrossingoverList)
        {
            _proxyCrossingoverList = new List<ProxyCrossingover>();
            _proxyCrossingoverList = proxyCrossingoverList;
            _random = new Random();
        }

        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChild)
        {
            double sumOfProgress = _proxyCrossingoverList.Sum(proxyCrossingover => proxyCrossingover.GetProgress());
            double[] sectorsOfWheel = new double[_proxyCrossingoverList.Count];
            for (int i = 0; i < _proxyCrossingoverList.Count; i++)
            {
                sectorsOfWheel[i] = _proxyCrossingoverList[i].GetProgress() / sumOfProgress * 100; // формула для поиска размера сектров колеса рулетки
            }

            int fallenSector = _random.Next(100);
            double sum = 0;
            for (int j = 0; j < sectorsOfWheel.Length; j++)
            {
                sum += sectorsOfWheel[j];
                if (sum > fallenSector)
                {
                    double currentResult = firstParent.GetTrackLength() < secondParent.GetTrackLength() ? firstParent.GetTrackLength() : secondParent.GetTrackLength();
                    double oneProcentGain = currentResult / 100;

                    DateTime startTime = DateTime.Now;
                    _proxyCrossingoverList[j].GetCrossingover().Crossingover(firstParent, secondParent, firstChild, secondChild);
                    DateTime endTime = DateTime.Now;
                    TimeSpan time = endTime - startTime;
                    _proxyCrossingoverList[j].AddOperationTime(time);

                    double newResult = firstChild.GetTrackLength() < secondChild.GetTrackLength() ? firstChild.GetTrackLength() : secondChild.GetTrackLength();
                    double procentGain;
                    if (newResult < currentResult)
                    {
                        procentGain = 100 - (newResult / oneProcentGain);
                        _proxyCrossingoverList[j].AddGoodStart();
                    }
                    else
                    {
                        procentGain = 0;
                        _proxyCrossingoverList[j].AddBadStart();
                    }
                    _proxyCrossingoverList[j].IncreaseProgress(procentGain);
                    break;
                }
            }

        }

        public string GetName()
        {
            return CrossingoverName;
        }
    }
}

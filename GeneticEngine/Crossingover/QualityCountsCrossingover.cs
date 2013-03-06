using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Crossingover
{
    public class QualityCountsCrossingover : AbstractCrossingover, ICrossingover
    {
        public const string CrossingoverName = "QualityCountsCrossingover";
        private List<ProxyCrossingover> _proxyCrossingoverList;
        private int _index; // mutation algorithm Index
        private double _bestResult;

        public QualityCountsCrossingover(List<ProxyCrossingover> proxyCrossingoverList, double bestResult)
        {
            _proxyCrossingoverList = new List<ProxyCrossingover>();
            _proxyCrossingoverList = proxyCrossingoverList;
            _index = 0;
            _bestResult = bestResult;
        }
        public void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild,
                                 AbstractTrack secondChild)
        {
            if (_index == _proxyCrossingoverList.Count)
            {
                _index = 0;
            }
            double currentResult = firstParent.GetTrackLength() < secondParent.GetTrackLength() ? firstParent.GetTrackLength() : secondParent.GetTrackLength();
            double oneProcentGain = (currentResult - _bestResult) / 100;

            DateTime startTime = DateTime.Now;
            _proxyCrossingoverList[_index].GetCrossingover().Crossingover(firstParent, secondParent, firstChild, secondChild);
            DateTime endTime = DateTime.Now;
            TimeSpan time = endTime - startTime;
            _proxyCrossingoverList[_index].AddOperationTime(time);

            double newResult = firstChild.GetTrackLength() < secondChild.GetTrackLength() ? firstChild.GetTrackLength() : secondChild.GetTrackLength();
            double procentGain;
            if (newResult < currentResult)
            {
                procentGain = 100 - (newResult - _bestResult) / oneProcentGain;
                _proxyCrossingoverList[_index].AddGoodStart();
            }
            else
            {
                procentGain = 0;
                _proxyCrossingoverList[_index].AddBadStart();
            }
            _proxyCrossingoverList[_index].IncreaseProgress(procentGain);
            _index++;
        }

        public string GetName()
        {
            return CrossingoverName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Crossingover;

namespace GeneticEngine.ProxyOperation
{
    public class ProxyCrossingover
    {
        private ICrossingover _crossingover;
        private int _numberOfGoodStarts;
        private int _numberOfBadStarts;
        private TimeSpan _operationTime;      // часы:минуты:секунды.милисекунды
        private double _progress;
        public ProxyCrossingover(ICrossingover crossingover)
        {
            _crossingover = crossingover;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
            _progress = 0;
        }

        public ICrossingover GetCrossingover()
        {
            return _crossingover;
        }
        public int NumberOfStarts
        {
            get { return _numberOfGoodStarts + _numberOfBadStarts; }
        }
        public int NumberOfGoodStarts
        {
            get { return _numberOfGoodStarts; }
        }
        public void AddGoodStart()
        {
            _numberOfGoodStarts++;
        }
        public int NumberOfBadStarts
        {
            get { return _numberOfBadStarts; }
        }
        public void AddBadStart()
        {
            _numberOfBadStarts++;
        }
        public TimeSpan GetOperationTime()
        {
            return _operationTime;
        }
        public void AddOperationTime(TimeSpan time)
        {
            _operationTime += time;
        }
        public double GetProgress()
        {
            return _progress;
        }
        public void IncreaseProgress(double procentGain)
        {
            _progress = (_progress + procentGain) / NumberOfStarts;
        }
        public string CrossingoverName
        {
            get { return _crossingover.GetName(); }
        }
    }
}

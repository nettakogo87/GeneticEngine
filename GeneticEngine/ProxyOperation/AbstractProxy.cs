using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.ProxyOperation
{
    public abstract class AbstractProxy
    {
        protected const int OneHundredPercent = 100;
        protected int _numberOfGoodStarts;
        protected int _numberOfBadStarts;
        protected TimeSpan _operationTime;      // часы:минуты:секунды.милисекунды
        protected double _progress;
        protected List<double> _progressList;

        public int NumberOfStarts
        {
            get { return _numberOfGoodStarts + _numberOfBadStarts; }
        }
        public int NumberOfGoodStarts
        {
            get { return _numberOfGoodStarts; }
        }
        public virtual void AddGoodStart()
        {
            _numberOfGoodStarts++;
        }
        public int NumberOfBadStarts
        {
            get { return _numberOfBadStarts; }
        }
        public virtual void AddBadStart()
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
            return _progress;  // Если мутация еще не запускалась, возвращает 100% 
        }
        public List<double> GetProgressList()
        {
            return _progressList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Crossingover;

namespace GeneticEngine.ProxyOperation
{
    public class ProxyCrossingover : AbstractProxy
    {
        private ICrossingover _crossingover;
        public ProxyCrossingover(ICrossingover crossingover)
        {
            _crossingover = crossingover;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
            _progressList = new List<double> { OneHundredPercent };
            _progress = OneHundredPercent;
        }
        public ICrossingover GetCrossingover()
        {
            return _crossingover;
        }
        public void IncreaseProgress(double procentGain)
        {
            _progressList.Add(procentGain);
            _progress = _progressList.Sum() / Convert.ToDouble(NumberOfStarts); // Общую сумму прогрессов разделить на кол-во запусков.
        }
    }
}

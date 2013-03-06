using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Selection;

namespace GeneticEngine.ProxyOperation
{
    public class ProxySelection
    {
        private ISelection _selection;
        private int _numberOfGoodStarts;
        private int _numberOfBadStarts;
        private TimeSpan _operationTime;      // часы:минуты:секунды.милисекунды
        public ProxySelection(ISelection selection)
        {
            _selection = selection;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
        }

        public ISelection GetSelection()
        {
            return _selection;
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
            return Convert.ToDouble(_numberOfGoodStarts)/(Convert.ToDouble(NumberOfStarts) / 100);
        }

        public string SelectionName
        {
            get { return _selection.GetName(); }
        }
    }
}

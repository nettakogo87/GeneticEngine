using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Selection;

namespace GeneticEngine.ProxyOperation
{
    public class ProxySelection : AbstractProxy
    {
        private ISelection _selection;
        public ProxySelection(ISelection selection)
        {
            _selection = selection;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
            _progressList = new List<double> { 1 };
            _progress = OneHundredPercent;
        }
        public ISelection GetSelection()
        {
            return _selection;
        }
        public override void AddGoodStart()
        {
            _numberOfGoodStarts++;
            _progressList.Add(1);
            _progress = Convert.ToDouble(_progressList.Sum()) / (Convert.ToDouble(NumberOfStarts) / 100);
        }
        public override void AddBadStart()
        {
            _numberOfBadStarts++;
            _progressList.Add(0);
            _progress = Convert.ToDouble(_progressList.Sum()) / (Convert.ToDouble(NumberOfStarts) / 100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Mutation;
/**
 * Класс для того что бы можно было мэпить на базу данных то, что в нем лежит
 * 
 */
namespace GeneticEngine.ProxyOperation
{
    public class ProxyMutation : AbstractProxy
    {
        private IMutation _mutation;
        public ProxyMutation(IMutation mutation)
        {
            _mutation = mutation;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
            _progressList = new List<double> {OneHundredPercent};
            _progress = OneHundredPercent;
        }
        public IMutation GetMutation()
        {
            return _mutation;
        }
        public void IncreaseProgress(double procentGain)
        {
            _progressList.Add(procentGain);
            _progress = _progressList.Sum() / Convert.ToDouble(NumberOfStarts); // Общую сумму прогрессов разделить на кол-во запусков.
        }
    }
}

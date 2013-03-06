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
    public class ProxyMutation
    {
        private IMutation _mutation;
        private int _numberOfGoodStarts;
        private int _numberOfBadStarts;
        private TimeSpan _operationTime;      // часы:минуты:секунды.милисекунды
        private double _progress;
        public ProxyMutation(IMutation mutation)
        {
            _mutation = mutation;
            _numberOfGoodStarts = 0;
            _numberOfBadStarts = 0;
            _progress = 1;
        }
        public IMutation GetMutation()
        {
            return _mutation;
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
            if (0 != NumberOfStarts)
            {
                return _progress / Convert.ToDouble(NumberOfStarts);
            }
            return _progress;  // Если мутация еще не запускалась, возвращает 100% 
        }
        public void IncreaseProgress(double procentGain)
        {
            _progress = _progress + procentGain;
        }
        public string MutationName
        {
            get { return _mutation.GetName(); }
        }
    }
}

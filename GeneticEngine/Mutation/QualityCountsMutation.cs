using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class QualityCountsMutation : AbstractMutation, IMutation
    {
        public const string MutationName = "QualityCountsMutation";
        private List<ProxyMutation> _proxyMutationList;
        private int _index; // mutation algorithm Index
        private double _bestResult;

        public QualityCountsMutation(List<ProxyMutation> proxyMutationList, double bestResult)
        {
            _proxyMutationList = new List<ProxyMutation>();
            _proxyMutationList = proxyMutationList;
            _index = 0;
            _bestResult = bestResult;
        }

        public void Mutation(AbstractTrack mutant)
        {
            if (_index == _proxyMutationList.Count)
            {
                _index = 0;
            }
            double currentResult = mutant.GetTrackLength();
            double oneProcentGain = (currentResult - _bestResult)/100;

            DateTime startTime = DateTime.Now;
            _proxyMutationList[_index].GetMutation().Mutation(mutant);
            DateTime endTime = DateTime.Now;
            TimeSpan time = endTime - startTime;
            _proxyMutationList[_index].AddOperationTime(time);

            double newResult = mutant.GetTrackLength();
            double procentGain;
            if (newResult < currentResult)
            {
                procentGain = 100 - (newResult - _bestResult) / oneProcentGain;
                _proxyMutationList[_index].AddGoodStart();
            }
            else
            {
                procentGain = 0;
                _proxyMutationList[_index].AddBadStart();
            }
            _proxyMutationList[_index].IncreaseProgress(procentGain);
            _index++;
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

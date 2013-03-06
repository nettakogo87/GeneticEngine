using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.ProxyOperation;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class SearchBestMutation : AbstractMutation, IMutation
    {
        public const string MutationName = "SearchBestMutation";
        private List<ProxyMutation> _proxyMutationList;
        private Random _random;

        public SearchBestMutation(List<ProxyMutation> proxyMutationList)
        {
            _proxyMutationList = new List<ProxyMutation>();
            _proxyMutationList = proxyMutationList;
            _random = new Random();
        }
        public void Mutation(AbstractTrack mutant)
        {
            double sumOfProgress = 0;
            for (int i = 0; i < _proxyMutationList.Count; i++)
            {
                sumOfProgress += _proxyMutationList[i].GetProgress();
            }
            double[] sectorsOfWheel = new double[_proxyMutationList.Count];
            for (int i = 0; i < _proxyMutationList.Count; i++)
            {
                sectorsOfWheel[i] = _proxyMutationList[i].GetProgress() / sumOfProgress * 100; // формула для поиска размера сектров колеса рулетки
            }

            int fallenSector = _random.Next(100);
            double sum = 0;
            for (int j = 0; j < sectorsOfWheel.Length; j++)
            {
                sum += sectorsOfWheel[j];
                if (sum > fallenSector)
                {
                    double currentResult = mutant.GetTrackLength();
                    double oneProcentGain = currentResult / 100;

                    DateTime startTime = DateTime.Now;
                    _proxyMutationList[j].GetMutation().Mutation(mutant);
                    DateTime endTime = DateTime.Now;
                    TimeSpan time = endTime - startTime;
                    _proxyMutationList[j].AddOperationTime(time);

                    double newResult = mutant.GetTrackLength();
                    double procentGain;
                    if (newResult < currentResult)
                    {
                        procentGain = 100 - (newResult / oneProcentGain);
                        _proxyMutationList[j].AddGoodStart();
                    }
                    else
                    {
                        procentGain = 0;
                        _proxyMutationList[j].AddBadStart();
                    }
                    _proxyMutationList[j].IncreaseProgress(procentGain);
                    break;
                }
            }
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.Mutation
{
    public class RandomMethodMutation : IMutation
    {
        public const string MutationName = "RandomMethodMutation";
        private List<IMutation> _mutationList;
        private string _previousMutationName;
        private double _previousResult;
        private double _newResult;

        public RandomMethodMutation(List<IMutation> mutationList)
        {
            _mutationList = new List<IMutation>();
            _mutationList = mutationList;
            _previousMutationName = MutationName;
        }

        public void Mutation(AbstractTrack mutant)
        {
            _previousResult = mutant.GetTrackLength();
            Random random = new Random();
            int numberOfMutation = random.Next(_mutationList.Count());
            while (_previousMutationName == _mutationList[numberOfMutation].GetName())
            {
                numberOfMutation = random.Next(_mutationList.Count());
            }
            _previousMutationName = _mutationList[numberOfMutation].GetName();
            _mutationList[numberOfMutation].Mutation(mutant);
            _newResult = mutant.GetTrackLength();
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

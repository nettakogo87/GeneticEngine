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

        public RandomMethodMutation(List<IMutation> mutationList)
        {
            _mutationList = new List<IMutation>();
            _mutationList = mutationList;
        }

        public void Mutation(AbstractTrack mutant)
        {
            Random random = new Random();
            int numberOfMutation = random.Next(_mutationList.Count());
            _mutationList[numberOfMutation].Mutation(mutant);
        }

        public string GetName()
        {
            return MutationName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Crossingover;
using GeneticEngine.FitnessFunction;
using GeneticEngine.Mutation;
using GeneticEngine.Selection;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine
{
    public class GEngine
    {
        public const int ProcentTreshhold = 100;

        public IFitnessFunction FitnessFunction
        {
            get { return _fitnessFunction; }
        }

        public AbstractTrack[] Tracks
        {
            get { return _tracks; }
        }

        private int _countOfPerson;
        private AbstractTrack[] _tracks;
        private int _pMutation;
        private int _pCrossingover;
        private IFitnessFunction _fitnessFunction;
        private IMutation _mutation;
        private ICrossingover _crossingover;
        private ISelection _selection;

        public GEngine(AbstractTrack[] tracks, int pCrossingover, int pMutation, IFitnessFunction fitnessFunction, IMutation mutation, ICrossingover crossingover, ISelection selection)
        {
            _countOfPerson = tracks.Length;
            _tracks = new AbstractTrack[_countOfPerson];
            _tracks = tracks;
            _pCrossingover = pCrossingover;
            _pMutation = pMutation;
            _fitnessFunction = fitnessFunction;
            _mutation = mutation;
            _crossingover = crossingover;
            _selection = selection;
        }


        public void Run()
        {
            Random random = new Random();
            while (_fitnessFunction.Fitness(_tracks))
            {
                AbstractTrack[] newGeneration = new AbstractTrack[_countOfPerson];
                for (int i = 0; i < _countOfPerson; i++)
                {
                    newGeneration[i] = _tracks[i].EmptyClone();
                }
                for (int i = 0; i < _countOfPerson; i++)
                {
                    int crossNotWillBe = random.Next(ProcentTreshhold);
                    if (_pCrossingover > crossNotWillBe)
                    {
                        int coupleIndex = random.Next(_countOfPerson - 1);
                        AbstractTrack firstChild = _tracks[i].EmptyClone();
                        AbstractTrack secondChild = _tracks[i].EmptyClone();
                        this.Crossingover(_tracks[i], _tracks[coupleIndex], firstChild, secondChild);
                        if (firstChild.GetTrackLength() <= secondChild.GetTrackLength())
                        {
                            int mutationNotWillBe = random.Next(ProcentTreshhold);
                            if (_pMutation > mutationNotWillBe)
                            {
                                this.Mutation(firstChild);
                            }
                            newGeneration[i] = firstChild;
                        }
                        else
                        {
                            int mutationNotWillBe = random.Next(ProcentTreshhold);
                            if (_pMutation > mutationNotWillBe)
                            {
                                this.Mutation(secondChild);
                            }
                            newGeneration[i] = secondChild;
                        }
                    }
                    else
                    {
                        int mutationNotWillBe = random.Next(ProcentTreshhold);
                        if (_pMutation > mutationNotWillBe)
                        {
                            AbstractTrack mutant = _tracks[i].EmptyClone();
                            _tracks[i].Genotype.CopyTo(mutant.Genotype, 0);
                            this.Mutation(mutant);
                            newGeneration[i] = mutant;
                        }
                        else
                        {
                            _tracks[i].Genotype.CopyTo(newGeneration[i].Genotype, 0);
                        }
                    }
                }
                this.Selection(_tracks, newGeneration);
            }
        }


        private void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            _selection.Selection(parentTracks, childTracks);
        }
        private void Mutation(AbstractTrack mutant)
        {
            _mutation.Mutation(mutant);
        }
        private void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild, AbstractTrack secondChaild)
        {
            _crossingover.Crossingover(firstParent, secondParent, firstChild, secondChaild);
        }
    }
}

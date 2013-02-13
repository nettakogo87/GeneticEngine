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
        public ICrossingover OnePointCrossingover
        {
            get { return _onePointCrossingover; }
        }

        public IMutation TwoPointMutation
        {
            get { return _twoPointMutation; }
        }

        public ISelection TournamentSelection
        {
            get { return _tournamentSelection; }
        }

        public IFitnessFunction FitnessFunction
        {
            get { return _fitnessFunction; }
        }

        public IGraph SalesmanGraph
        {
            get { return _salesmanGraph; }
        }

        public AbstractTrack[] Tracks
        {
            get { return _tracks; }
        }

        private ICrossingover _onePointCrossingover;
        private IMutation _twoPointMutation;
        private ISelection _tournamentSelection;
        private IFitnessFunction _fitnessFunction;
        private AbstractTrack[] _tracks;
        private IGraph _salesmanGraph;
        private int _pMutation;
        private int _pCrossingover;
        private int _countOfAllele;
        private int _countOfPerson;
        private string _typeOfTrack;

        public GEngine(IGraph salesmanGraph, AbstractTrack[] tracks, int pCrossingover, int pMutation, IFitnessFunction fitnessFunction)
        {
            _countOfPerson = tracks.Length;
            _salesmanGraph = salesmanGraph;
            _tracks = new AbstractTrack[_countOfPerson];
            _tracks = tracks;
            _pCrossingover = pCrossingover;
            _pMutation = pMutation;
            _countOfAllele = _tracks[0].Genotype.Length;
            _onePointCrossingover = new OnePointCrossingover();
            _twoPointMutation = new TwoPointMutation();
            _tournamentSelection = new Tournament();
            _fitnessFunction = fitnessFunction;
        }


        public void Run()
        {
            Random random = new Random();
            AbstractTrack[] newGeneration = new AbstractTrack[_countOfPerson];
            while (_fitnessFunction.Fitness(_tracks, _salesmanGraph))
            {
                for (int i = 0; i < _countOfPerson; i++)
                {
                    int crossNotWillBe = random.Next(_pCrossingover);
                    if (_pCrossingover > crossNotWillBe)
                    {
                        int coupleIndex = random.Next(_countOfPerson - 1);
                        AbstractTrack firstChild = _tracks[i].EmptyClone();
                        AbstractTrack secondChild = _tracks[i].EmptyClone();
                        this.Crossingover(_tracks[i], _tracks[coupleIndex], firstChild, secondChild);
                        if (firstChild.GetTrackLength(_salesmanGraph) <= secondChild.GetTrackLength(_salesmanGraph))
                        {
                            int mutationNotWillBe = random.Next(_pMutation);
                            if (_pMutation > mutationNotWillBe)
                            {
                                this.Mutation(firstChild);
                            }
                            newGeneration[i] = firstChild;
                        }
                        else
                        {
                            int mutationNotWillBe = random.Next(_pMutation);
                            if (_pMutation > mutationNotWillBe)
                            {
                                this.Mutation(secondChild);
                            }
                            newGeneration[i] = secondChild;
                        }
                    }
                    else
                    {
                        int mutationNotWillBe = random.Next(_pMutation);
                        if (_pMutation > mutationNotWillBe)
                        {
                            AbstractTrack mutant = _tracks[i].EmptyClone();
                            mutant.Genotype.CopyTo(_tracks[i].Genotype, 0);
                            this.Mutation(mutant);
                            newGeneration[i] = mutant;
                        }
                        else
                        {
                            newGeneration[i].Genotype.CopyTo(_tracks[i].Genotype, 0);
                        }
                    }
                }
                this.Selection(_tracks, newGeneration, _salesmanGraph);
            }
        }


        private void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks, IGraph graph)
        {
            _tournamentSelection.Selection(parentTracks, childTracks, graph);
        }
        private void Mutation(AbstractTrack mutant)
        {
            _twoPointMutation.Mutation(mutant);
        }
        private void Crossingover(AbstractTrack firstParent, AbstractTrack secondParent, AbstractTrack firstChild, AbstractTrack secondChaild)
        {
            _onePointCrossingover.Crossingover(firstParent, secondParent, firstChild, secondChaild);
        }
    }
}

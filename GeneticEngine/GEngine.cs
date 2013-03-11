using System;
using System.Collections.Generic;
using System.Data;
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

        private int _numberOfGenerations;
        private int _countOfPerson;
        private AbstractTrack[] _tracks;
        private int _pMutation;
        private int _pCrossingover;
        private IFitnessFunction _fitnessFunction;
        private IMutation _mutation;
        private ICrossingover _crossingover;
        private ISelection _selection;
        private TimeSpan _operationTime;
        private DateTime _startTime;
        private DateTime _endTime;
        private DB_GeneticsDataSet _geneticsDataSet;
        private Guid _launchId; 

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
            _geneticsDataSet = new DB_GeneticsDataSet();
            _launchId = Guid.NewGuid();
        }

        public void Run()
        {
            DB_GeneticsDataSetTableAdapters.LaunchesTableAdapter LaunchTableAdapter =
                new DB_GeneticsDataSetTableAdapters.LaunchesTableAdapter();
            DB_GeneticsDataSet.LaunchesRow newLaunchRow = _geneticsDataSet.Launches.NewLaunchesRow();
            newLaunchRow.Id = _launchId;
            _startTime = DateTime.Now;
            Random random = new Random();
            while (_fitnessFunction.Fitness(_tracks))
            {
                _numberOfGenerations++;
                foreach (AbstractTrack track in _tracks)
                {
                    SaveTrack(track);
                }
                AbstractTrack[] newGeneration = new AbstractTrack[_countOfPerson];
                for (int i = 0; i < _countOfPerson; i++)
                {
                    int crossNotWillBe = random.Next(ProcentTreshhold);
                    if (_pCrossingover > crossNotWillBe)
                    {
                        // Скрещивание
                        int coupleIndex = random.Next(_countOfPerson - 1);
                        AbstractTrack firstChild = _tracks[i].EmptyClone();
                        AbstractTrack secondChild = _tracks[i].EmptyClone();

                        this.Crossingover(_tracks[i], _tracks[coupleIndex], firstChild, secondChild);
                        firstChild.FirstParent = _tracks[i].GetItem();
                        firstChild.SecondParent = _tracks[coupleIndex].GetItem();
                        secondChild.FirstParent = _tracks[i].GetItem();
                        secondChild.SecondParent = _tracks[coupleIndex].GetItem();

                        SaveTrack(secondChild);
                        SaveTrack(firstChild);

                        if (firstChild.GetTrackLength() <= secondChild.GetTrackLength())
                        {
                            MutationWrapper(firstChild, newGeneration, random, i);
                        }
                        else
                        {
                            MutationWrapper(secondChild, newGeneration, random, i);
                        }
                    }
                    else
                    {
                        AbstractTrack mutant = _tracks[i].Clone();
                        MutationWrapper(mutant, newGeneration, random, i);
                    }
                }
                // Селекция
                this.Selection(_tracks, newGeneration);
                for (int i = 0; i < _tracks.Length; i++)
                {
                    SaveTrack(_tracks[i]);
                }
            }
            _endTime = DateTime.Now;
            _operationTime = _endTime - _startTime;


            newLaunchRow.StartTime = _startTime;
            newLaunchRow.EndTime = _endTime;
            newLaunchRow.OperationTime = _operationTime.ToString();
            newLaunchRow.TypeOfMutation = _mutation.GetName();
            newLaunchRow.TypeOfSelection = _selection.GetName();
            newLaunchRow.TypeOfCrossingover = _crossingover.GetName();
            newLaunchRow.FitnessFunction = _fitnessFunction.GetName();
            newLaunchRow.NumberOfGenerations = _numberOfGenerations.ToString();
            newLaunchRow.BestResult = FitnessFunction.BestResult.ToString();
            _geneticsDataSet.Launches.Rows.Add(newLaunchRow);
//            LaunchTableAdapter.Update(newLaunchRow);
//            _geneticsDataSet.Launches.AcceptChanges();
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

        public TimeSpan GetOperationTime()
        {
            return _operationTime;
        }

        private void MutationWrapper(AbstractTrack child, AbstractTrack[] newGeneration, Random random, int i)
        {
            child.TypeOfSelection = AbstractSelection.WithoutSelection;
            child.TypeOfCrossingover = AbstractCrossingover.WithoutCrossingover;

            int mutationNotWillBe = random.Next(ProcentTreshhold);
            if (_pMutation > mutationNotWillBe)
            {
                // Мутация
                this.Mutation(child);
                newGeneration[i] = child;
                SaveTrack(child);
            }
            else
            {
                newGeneration[i] = child;
            }
        }

        private void SaveTrack(AbstractTrack track)
        {
            DB_GeneticsDataSet.PersonsRow newPersonRow = _geneticsDataSet.Persons.NewPersonsRow();
            newPersonRow.Id = Guid.NewGuid();
            newPersonRow.Item = track.GetItem();
            newPersonRow.Track = track.Genotype.ToString();
            newPersonRow.Length = track.GetTrackLength();
            newPersonRow.TypeOfCrossingover = track.TypeOfCrossingover;
            newPersonRow.TypeOfMutation = track.TypeOfMutation;
            newPersonRow.TypeOfSelection = track.TypeOfSelection;
            newPersonRow.NumberOfGeneration = _numberOfGenerations;
            newPersonRow.FirstParent = track.FirstParent;
            newPersonRow.SecondParent = track.SecondParent;
            newPersonRow.Launch = _launchId;
            newPersonRow.BestRip = track.GetBestRip().ToString();
            newPersonRow.WorstRip = track.GetWorstRip().ToString();
            newPersonRow.TypeOfTrack = track.GetTypeOfTrack();
            _geneticsDataSet.Persons.Rows.Add(newPersonRow);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.FitnessFunction
{
    public class BestReps : IFitnessFunction
    {
        private int _specifiedCountOfReps;
        private int _actualCountOfReps;
        private double _bestResult;
        
        public BestReps(int countOfReps)
        {
            _specifiedCountOfReps = countOfReps;
            _actualCountOfReps = 0;
            _bestResult = 0;
        }

        public bool Fitness(AbstractTrack[] tracks)
        {
            double[] results = new double[tracks.Length];
            for (int i = 0; i < tracks.Length; i++)
            {
                results[i] = tracks[i].GetTrackLength();
            }
            double minTracksResult = results.Min();

            if (0 == _bestResult.CompareTo(minTracksResult))
            {
                _actualCountOfReps++;
            }
            else
            {
                _bestResult = minTracksResult;
                _actualCountOfReps = 1;
            }
            if (_actualCountOfReps == _specifiedCountOfReps)
            {
                return false;
            }
            return true;
        }

        public double BestResult
        {
            get { return _bestResult; }
        }

        public int ActualCountOfReps
        {
            get { return _actualCountOfReps; }
        }
    }
}

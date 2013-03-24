using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.FitnessFunction
{
    public class GenerationCounter : IFitnessFunction
    {
        public const string FitnessFunctionName = "GenerationCounter";
        private int _specifiedCountOfReps;
        private int _actualCountOfReps;
        private double _bestResult;

        public GenerationCounter(int specifiedCountOfReps)
        {
            _specifiedCountOfReps = specifiedCountOfReps;
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
            _bestResult = results.Min();

            _actualCountOfReps++;
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

        public string GetName()
        {
            return FitnessFunctionName;
        }
    }
}

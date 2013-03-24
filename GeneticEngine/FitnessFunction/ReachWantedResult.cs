using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Track;

namespace GeneticEngine.FitnessFunction
{
    public class ReachWantedResult : IFitnessFunction
    {
        public const string FitnessFunctionName = "ReachWantedResult";

        private int _actualCountOfReps;
        private double _bestResult;
        public ReachWantedResult(double wantedBestResult)
        {
            _bestResult = wantedBestResult;
            _actualCountOfReps = 0;
        }
        public bool Fitness(AbstractTrack[] tracks)
        {
            double[] results = new double[tracks.Length];
            for (int i = 0; i < tracks.Length; i++)
            {
                results[i] = tracks[i].GetTrackLength();
            }
            double minTracksResult = results.Min();
            _actualCountOfReps++;
            if ((0 == _bestResult.CompareTo(minTracksResult)) || (1 == _bestResult.CompareTo(minTracksResult)))
            {
                _bestResult = minTracksResult;
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

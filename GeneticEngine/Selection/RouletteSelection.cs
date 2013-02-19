using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class RouletteSelection : ISelection
    {
        private string _name;

        public RouletteSelection()
        {
            _name = "RouletteSelection";
        }

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks, IGraph graph)
        {
            int countOfTracks = parentTracks.Length;
            AbstractTrack[] allTracks = new AbstractTrack[countOfTracks * 2];
            for (int i = 0; i < countOfTracks; i++)
            {
                allTracks[i] = parentTracks[i].Clone();
                allTracks[i + countOfTracks] = childTracks[i].Clone();
            }

            Random random = new Random();
            double sumOfFitness = 0;
            for (int i = 0; i < countOfTracks * 2; i++)
            {
                sumOfFitness += allTracks[i].GetTrackLength(graph);
            }
            double[] sectorsOfWheel = new double[countOfTracks * 2];
            for (int i = 0; i < countOfTracks * 2; i++)
            {
                sectorsOfWheel[i] = allTracks[i].GetTrackLength(graph) / sumOfFitness * 100; // формула для поиска размера сектров колеса рулетки
            }
            for (int i = 0; i < countOfTracks; i++)
            {
                int fallenSector = random.Next(100);
                double sum = 0;
                for (int j = 0; j < sectorsOfWheel.Length; j++)
                {
                    sum += sectorsOfWheel[j];
                    if (sum > fallenSector)
                    {
                        parentTracks[i] = allTracks[j];
                        break;
                    }
                }
            }
        }


        public string GetName()
        {
            return _name;
        }

    }
}

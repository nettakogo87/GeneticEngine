using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public class RouletteSelection : AbstractSelection, ISelection
    {
        public const string SelectionName = "RouletteSelection";

        public void Selection(AbstractTrack[] parentTracks, AbstractTrack[] childTracks)
        {
            int countOfTracks = parentTracks.Length;
            AbstractTrack[] allTracks = new AbstractTrack[countOfTracks * 2];
            for (int i = 0; i < countOfTracks; i++)
            {
                allTracks[i] = parentTracks[i].Clone();
                allTracks[i + countOfTracks] = childTracks[i].Clone();
            }
                                                                        // todo чето тут не так!!!!!!!!!!!!!!!!
            Random random = new Random();
            double sumOfFitness = 0;
            for (int i = 0; i < countOfTracks * 2; i++)
            {
                sumOfFitness += allTracks[i].GetTrackLength();
            }
            double[] sectorsOfWheel = new double[countOfTracks * 2];
            for (int i = 0; i < countOfTracks * 2; i++)
            {
                sectorsOfWheel[i] = allTracks[i].GetTrackLength() / sumOfFitness * 100; // формула для поиска размера сектров колеса рулетки
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
                        parentTracks[i].TypeOfSelection = SelectionName;
                        break;
                    }
                }
            }
        }

        public string GetName()
        {
            return SelectionName;
        }

    }
}

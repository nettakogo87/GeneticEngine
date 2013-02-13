using GeneticEngine.Graph;

namespace GeneticEngine.Track
{
    /**
     * Для контроля за тем как получаетются особи, каждая особь хранит в себе данные об этом:
     * "Тип селекции, тип мутации, тип скрещивания".
     */
    public interface ITrack
    {
        double GetTrackLength(IGraph graph);
        int[] Genotype { get; set; }
        string TypeOfSelection { get; set; }
        string TypeOfMutation { get; set; }
        string TypeOfCrossingover { get; set; }
        string TypeOfTrack { get; }
    }
}

using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngine.Selection
{
    public interface ISelection
    {
        void Selection(ITrack[] parentTracks, ITrack[] childTracks, IGraph graph);
        string GetName();
    }
}

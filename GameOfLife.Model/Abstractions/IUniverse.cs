namespace GameOfLife.Model;

public interface IUniverse<TGeneration, TRules, TCell>
    : IEnumerable<TGeneration>
    where TGeneration : IGeneration<TCell>
    where TRules : IGameRules<TGeneration, TCell>
{
    //
    // Summary:
    //     The pattern from which the game starts.
    public TGeneration Initial { get; }
    //
    // Summary:
    //     Applies game rules that change passed grid.
    public TRules Rules { get; }
}

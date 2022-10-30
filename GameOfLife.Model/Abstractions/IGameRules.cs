namespace GameOfLife.Model;

public interface IGameRules<TGeneration, TCell>
    where TGeneration : IGeneration<TCell>
{
    //
    // Summary:
    //     Applies game rules that change passed generation.
    //
    // Returns:
    //     A new generation changed by rules.
    TGeneration Apply(TGeneration grid);
}

namespace GameOfLife.Model;

public interface IGeneration<TCell> : IEnumerable<TCell>
{
    //
    // Summary:
    //     Represents the first dimension of the game.
    public int Columns { get; }
    //
    // Summary:
    //     Represents the second dimension of the game.
    public int Rows { get; }
}

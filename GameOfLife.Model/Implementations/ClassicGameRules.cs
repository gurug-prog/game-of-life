namespace GameOfLife.Model;

public sealed class ClassicGameRules : IGameRules<ClassicGeneration, ClassicCell>
{
    public static ClassicGameRules Instance
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public ClassicGeneration Apply(ClassicGeneration grid)
    {
        throw new NotImplementedException();
    }
}

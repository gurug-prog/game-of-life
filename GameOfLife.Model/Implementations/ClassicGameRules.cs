namespace GameOfLife.Model;

public sealed class ClassicGameRules : IGameRules<ClassicGeneration, ClassicCell>
{
    private static ClassicGameRules? _rules = null;

    public static ClassicGameRules Instance
        => _rules ??= new ClassicGameRules();

    private ClassicGameRules()
    {
    }

    public ClassicGeneration Apply(ClassicGeneration generation)
    {
        var newGeneration = new ClassicCell[generation.Rows, generation.Columns];

        for (int row = 0; row < generation.Rows; row++)
        {
            for (int column = 0; column < generation.Columns; column++)
            {
                newGeneration[row, column] = CalculateCellStatus(generation, row, column);
            }
        }

        return new ClassicGeneration(newGeneration);
    }

    private static ClassicCell CalculateCellStatus(
            ClassicGeneration current,
            int row,
            int column)
    {
        var neighbours = GetCellNeighbours(current, row, column);
        var aliveNeighbours = neighbours.Count(
            neighbourState => neighbourState == ClassicCell.Alive);
        
        var cellState = current.Map[row, column];
        switch (cellState)
        {
            case ClassicCell.Alive:
                var cellWillStayAlive =
                    aliveNeighbours == 2 || aliveNeighbours == 3;
                if (!cellWillStayAlive)
                {
                    cellState = ClassicCell.Dead;
                }
                break;
            case ClassicCell.Dead:
                var cellWillBeBorn = aliveNeighbours == 3;
                if (cellWillBeBorn)
                {
                    cellState = ClassicCell.Alive;
                }
                break;
            default:
                throw new ArgumentException(
                    $"Unexpected {nameof(cellState)} status value.");
        }

        return cellState;
    }

    private static IEnumerable<ClassicCell> GetCellNeighbours(
        ClassicGeneration current,
        int row,
        int column)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                var isCurrentCell = i == 0 && j == 0;
                if (isCurrentCell) continue;

                var normalizedRow = Normalize(row + i, current.Rows);
                var normalizedColumn = Normalize(column + j, current.Columns);

                yield return current.Map[normalizedRow, normalizedColumn];
            }
        }
    }

    private static int Normalize(int current, int total)
        => (current + total) % total;
}

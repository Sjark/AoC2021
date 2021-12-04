namespace AoC2021.Day4;

public class Day4 : ISolution
{
    public void Execute()
    {
        var bingoInput = File.ReadAllLines($"{AppContext.BaseDirectory}\\Day4\\input.txt")
            .AsSpan();

        var randomNumbers = bingoInput[0].Split(',').ToList().Select(a => int.Parse(a.Trim()));
        var boards = new List<BingoBoard>();

        for (int i = 2; i < bingoInput.Length; i += 6)
        {
            boards.Add(new BingoBoard(bingoInput.Slice(i, 5)));
        }

        BingoBoard? firstBingoBoard = null;
        int currentNumber = 0;

        foreach (var number in randomNumbers)
        {
            foreach (var board in boards)
            {
                if (board.HasBingo(number))
                {
                    firstBingoBoard = board;
                    currentNumber = number;

                    break;
                }
            }

            if (firstBingoBoard != null)
            {
                break;
            }
        }

        Console.WriteLine($"A: {firstBingoBoard?.Score(currentNumber)}");

        boards = new List<BingoBoard>();

        for (int i = 2; i < bingoInput.Length; i += 6)
        {
            boards.Add(new BingoBoard(bingoInput.Slice(i, 5)));
        }

        foreach (var number in randomNumbers)
        {
            foreach (var board in boards.ToList())
            {
                if (board.HasBingo(number))
                {
                    firstBingoBoard = board;
                    currentNumber = number;

                    boards.Remove(board);
                }
            }
        }

        Console.WriteLine($"B: {firstBingoBoard?.Score(currentNumber)}");
    }
}

public class BingoBoard
{
    private readonly (int Number, bool IsMarked)[,] _board = new (int, bool)[5,5];
    
    public BingoBoard(Span<string> rows)
    {
        for (int i = 0; i < rows.Length; i++)
        {
            var row = rows[i];
            var columns = row.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a.Trim())).ToList();

            for (int j = 0; j < columns.Count; j++)
            {
                var column = columns[j];
                _board[i, j] = (column, false);
            }
        }
    }

    public bool HasBingo(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (_board[i, j].Number == number)
                {
                    _board[i, j].IsMarked = true;

                    return CheckForBingo(i, j);
                }
            }
        }

        return false;
    }

    public int Score(int number)
    {
        var sumOfUnmarked = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (!_board[i, j].IsMarked)
                {
                    sumOfUnmarked += _board[i, j].Number;
                }
            }
        }

        return sumOfUnmarked * number;
    }

    private bool CheckForBingo(int row, int column)
    {
        var isBingoRow = true;
        var isBingoColumn = true;

        for (int i = 0; i < 5; i++)
        {
            if (isBingoRow && !_board[row, i].IsMarked)
            {
                isBingoRow = false;
            }

            if (isBingoColumn && !_board[i, column].IsMarked)
            {
                isBingoColumn = false;
            }
        }

        return isBingoRow || isBingoColumn;
    }
}

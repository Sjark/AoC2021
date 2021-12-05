namespace AoC2021.Day5;

public class Day5 : ISolution
{
    public void Execute()
    {
        var vents = File.ReadAllLines($"{AppContext.BaseDirectory}\\Day5\\input.txt");
        var grid = new int[1000, 1000];

        foreach (var vent in vents)
        {
            var cords = vent.Split(" -> ");

            var from = cords[0].Split(',').Select(a => int.Parse(a)).ToList();
            var fromX = from[0];
            var fromY = from[1];

            var to = cords[1].Split(',').Select(a => int.Parse(a)).ToList();
            var toX = to[0];
            var toY = to[1];

            if (fromX == toX)
            {
                for (int i = Math.Min(fromY, toY); i <= Math.Max(fromY, toY); i++)
                {
                    grid[fromX, i]++;
                }
            }
            else if (fromY == toY)
            {
                for (int i = Math.Min(fromX, toX); i <= Math.Max(fromX, toX); i++)
                {
                    grid[i, fromY]++;
                }
            }
        }

        var atLeastTwoLinesOverlap = 0;

        for (int i = 0; i < 1000; i++)
        {
            for (int y = 0; y < 1000; y++)
            {
                if (grid[i, y] > 1)
                {
                    atLeastTwoLinesOverlap++;
                }
            }
        }

        Console.WriteLine($"A: {atLeastTwoLinesOverlap}");
        
        foreach (var vent in vents)
        {
            var cords = vent.Split(" -> ");

            var from = cords[0].Split(',').Select(a => int.Parse(a)).ToList();
            var fromX = from[0];
            var fromY = from[1];

            var to = cords[1].Split(',').Select(a => int.Parse(a)).ToList();
            var toX = to[0];
            var toY = to[1];

            if (fromX != toX && fromY != toY)
            {
                if (fromX > toX && fromY > toY)
                {
                    var y = toY;

                    for (int x = toX; x <= fromX; x++)
                    {
                        grid[x, y]++;
                        y++;
                    }
                }
                else if (fromX > toX && fromY < toY)
                {
                    var y = toY;

                    for (int x = toX; x <= fromX; x++)
                    {
                        grid[x, y]++;
                        y--;
                    }
                }
                else if (fromX < toX && fromY > toY)
                {
                    var y = fromY;

                    for (int x = fromX; x <= toX; x++)
                    {
                        grid[x, y]++;
                        y--;
                    }
                }
                else if (fromX < toX && fromY < toY)
                {
                    var y = fromY;

                    for (int x = fromX; x <= toX; x++)
                    {
                        grid[x, y]++;
                        y++;
                    }
                }
            }
        }

        atLeastTwoLinesOverlap = 0;

        for (int i = 0; i < 1000; i++)
        {
            for (int y = 0; y < 1000; y++)
            {
                if (grid[i, y] > 1)
                {
                    atLeastTwoLinesOverlap++;
                }
            }
        }

        Console.WriteLine($"B: {atLeastTwoLinesOverlap}");
    }
}

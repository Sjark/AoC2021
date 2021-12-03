using System.Text;

namespace AoC2021.Day3;

public class Day3 : ISolution
{
    public void Execute()
    {
        var diagnostics = File.ReadAllLines($"{AppContext.BaseDirectory}\\Day3\\input.txt");

        var gammaRate = new StringBuilder();

        for (int i = 0; i < diagnostics[0].Length; i++)
        {
            var zeroCount = 0;
            var oneCount = 0;

            for (int j = 0; j < diagnostics.Length; j++)
            {
                if (diagnostics[j][i] == '1')
                {
                    oneCount++;
                }
                else
                {
                    zeroCount++;
                }
            }

            if (zeroCount > oneCount)
            {
                gammaRate.Append('0');
            }
            else 
            { 
                gammaRate.Append('1'); 
            }
        }

        var binaryGammaRate = Convert.ToInt32(gammaRate.ToString(), 2);
        var mask = (1 << 12) - 1;
        var binaryEpsilonRate = ~binaryGammaRate & mask;

        Console.WriteLine($"A: {binaryGammaRate * binaryEpsilonRate}");

        var oxygenGeneratorList = diagnostics.ToList();
        var co2ScrubberList = diagnostics.ToList();

        for (int i = 0; i < diagnostics[0].Length; i++)
        {
            var zeroCount = 0;
            var oneCount = 0;

            if (oxygenGeneratorList.Count > 1)
            {
                for (int j = 0; j < oxygenGeneratorList.Count; j++)
                {
                    if (oxygenGeneratorList[j][i] == '1')
                    {
                        oneCount++;
                    }
                    else
                    {
                        zeroCount++;
                    }
                }

                var currentOxygenBit = oneCount >= zeroCount ? '1' : '0';
                oxygenGeneratorList = oxygenGeneratorList.Where(a => a[i] == currentOxygenBit).ToList();
            }

            if (co2ScrubberList.Count > 1)
            {
                zeroCount = 0;
                oneCount = 0;

                for (int j = 0; j < co2ScrubberList.Count; j++)
                {
                    if (co2ScrubberList[j][i] == '1')
                    {
                        oneCount++;
                    }
                    else
                    {
                        zeroCount++;
                    }
                }

                var currentCo2Bit = zeroCount <= oneCount ? '0' : '1';
                co2ScrubberList = co2ScrubberList.Where(a => a[i] == currentCo2Bit).ToList();
            }
        }

        var oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorList.First(), 2);
        var co2ScrubberRating = Convert.ToInt32(co2ScrubberList.First(), 2);

        Console.WriteLine($"B: {oxygenGeneratorRating * co2ScrubberRating}");
    }
}

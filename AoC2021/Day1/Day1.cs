using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Day1
{
    public class Day1 : ISolution
    {
        public void Execute()
        {
            var numbers = File.ReadAllLines($"{AppContext.BaseDirectory}\\Day1\\input.txt").Select(x => int.Parse(x.Trim())).ToList();

            var previousNum = numbers.First();
            var increases = 0;

            foreach (var number in numbers.Skip(1))
            {
                if (number > previousNum)
                {
                    increases++;
                }

                previousNum = number;
            }

            Console.Write("A: ");
            Console.WriteLine(increases);

            increases = 0;

            for (int i = 0; i < numbers.Count - 3; i++)
            {
                if ((numbers[i] + numbers[i + 1] + numbers[i + 2]) < (numbers[i + 1] + numbers[i + 2] + numbers[i + 3])) {
                    increases++;
                }
            }

            Console.Write("B: ");
            Console.WriteLine(increases);
        }
    }
}

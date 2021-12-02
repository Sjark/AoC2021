using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Day2
{
    public class Day2 : ISolution
    {
        public void Execute()
        {
            var instructions = File.ReadAllLines($"{AppContext.BaseDirectory}\\Day2\\input.txt")
                .Select(a => new { Command = a.Split(' ').First(), Units = int.Parse(a.Split(' ').Last().Trim()) })
                .ToList();

            var horizontalPos = 0;
            var depth = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Command)
                {
                    case "forward":
                        horizontalPos += instruction.Units;
                        break;
                    case "up":
                        depth -= instruction.Units;
                        break;
                    case "down":
                        depth += instruction.Units;
                        break;
                    default:
                        break;
                }
            }

            Console.Write("A: ");
            Console.WriteLine(horizontalPos * depth);

            horizontalPos = 0;
            depth = 0;
            var aim = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Command)
                {
                    case "forward":
                        horizontalPos += instruction.Units;
                        depth += instruction.Units * aim;
                        break;
                    case "up":
                        aim -= instruction.Units;
                        break;
                    case "down":
                        aim += instruction.Units;
                        break;
                    default:
                        break;
                }
            }

            Console.Write("B: ");
            Console.WriteLine(horizontalPos * depth);
        }
    }
}

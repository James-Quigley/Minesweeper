using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard(10, 10, 10);
            while (!game.gameOver && !game.win) { 
                //Console.Clear();
                game.printBoard(true);
                Console.WriteLine();
                Console.WriteLine("a) click tile");
                Console.WriteLine("b) flag tile");
                char c = (char)Console.Read();
                if (c.Equals('a'))
                {
                    int x = int.Parse(Console.ReadLine());
                    int y = int.Parse(Console.ReadLine());
                    game.onClick(x, y);
                }
                else
                {
                    int x = int.Parse(Console.ReadLine());
                    int y = int.Parse(Console.ReadLine());
                    game.onRightClick(x, y);
                }
            }
            if (game.win)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("BOOM!");
            }
            game.printBoard(true);
            Console.Read();
        }
    }
}

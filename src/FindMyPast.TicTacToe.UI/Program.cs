using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FindMyPast.TicTacToe.Logic;
using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.UI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Sohail's Noughts and Crosses - press any key to start");

            Console.ReadKey();
            Console.WriteLine();

            //Outer loop of application - allowing you to play game repeatedly
            while (true)
            {
                Game.PlayGame();

                Console.WriteLine("Press Y to play again, or any other key to exit.");

                if (Console.ReadKey().Key != ConsoleKey.Y)
                    break;

                Console.WriteLine();
            }
            

        }
    }
}

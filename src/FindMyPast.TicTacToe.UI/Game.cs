using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using Autofac.Core;
using FindMyPast.TicTacToe.Logic;
using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.UI
{
    /// <summary>
    /// Simple static method to play game 
    /// 
    /// As much logic as possible is in the logic assembly,
    /// so this method is really only to take a turn and then either exit with an appropriate message
    /// or toggle piece (i.e. nought or cross), pause and then carry on
    /// </summary>
    static class Game
    {
        internal static void PlayGame()
        {
            var container = Bootstrap.GetContainer(); //initiate IoC container

            var currentPiece = PieceType.Nought; //nought always starts
            var board = container.Resolve<IBoard>();
            var boardIsPlayable = true;

            Console.WriteLine(board.RenderAsText());
            Console.WriteLine();

            while (boardIsPlayable)
            {
                var status = board.AssignPieceToBoard(currentPiece);

                Console.WriteLine(board.RenderAsText());
                Console.WriteLine();

                switch (status)
                {
                     case BoardStatus.NoughtsWins:
                        Console.WriteLine("Noughts win!");
                        boardIsPlayable = false;
                        break;

                    case BoardStatus.CrossesWins:
                        Console.WriteLine("Crosses win!");
                        boardIsPlayable = false;
                        break;

                    case BoardStatus.Full:
                        Console.WriteLine("No-one won!!");
                        boardIsPlayable = false;
                        break;

                    case BoardStatus.StillPlayable:
                        break;
                }

                currentPiece =
                    (currentPiece == PieceType.Nought) ? PieceType.Cross : PieceType.Nought;

                Thread.Sleep(1000);

            }            

        }


    }
}
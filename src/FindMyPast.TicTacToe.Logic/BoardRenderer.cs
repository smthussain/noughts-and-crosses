using System;
using System.Collections.Generic;
using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// For such a simple game, a simple hardcoded render of each cell does the job. For a more complex
    /// game, we'd generate it procedurally
    /// </summary>
    internal class BoardRenderer : IBoardRenderer
    {
        private readonly Dictionary<PieceType, char> _renderLookup = new Dictionary<PieceType, char>
            {
                {PieceType.Neither, ' '},
                {PieceType.Nought,'O'},
                {PieceType.Cross, 'X'},
            };

        public string RenderAsText(IBoardCells boardCells)
        {
            Func<int, char> cell = x => _renderLookup[boardCells.GetCell(x)];

            return string.Format(
                " {0} | {1} | {2} \n" +
                "-----------\n" +
                " {3} | {4} | {5} \n" +
                "-----------\n" +
                " {6} | {7} | {8} \n",
                cell(0), cell(1), cell(2),
                cell(3), cell(4), cell(5),
                cell(6), cell(7), cell(8)
            );
        }
    }
}

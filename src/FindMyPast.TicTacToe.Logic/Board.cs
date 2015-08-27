using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// This does the work of IBoard. For SRP, we've farmed out most complex logic into three injected-in components
    /// (see their interface definitions for what they do)
    /// </summary>
    internal class Board : IBoard
    {
        private readonly IBoardCells _boardCells;
        private readonly IBoardWinningRules _boardWinningRules;
        private readonly IBoardRenderer _boardRenderer;

        private readonly Random _random;
        private readonly int _boardSize;


        public Board(IBoardCells boardCells, IBoardWinningRules boardWinningRules, IBoardRenderer boardRenderer)
        {
            _boardCells = boardCells;
            _boardRenderer = boardRenderer;
            _boardWinningRules = boardWinningRules;

            _random = new Random(DateTime.Now.Millisecond); //seed is current time's milliseconds, which is a simple way to get a random number
            _boardSize = _boardCells.Size();
        }


        /// <summary>
        /// Allow the placing of a piece on the board, subject to certain conditions. It then uses
        /// both IBoardWinningRules and IBoardCells to work out the current state of the board
        /// </summary>
        /// <param name="piece">Type of piece to place on board - Nought or Cross</param>
        /// <returns>State of the board after applyin the piece - either having a winner (and which one), full or still playable</returns>      
        public BoardStatus AssignPieceToBoard(PieceType piece)
        {
            if (_boardCells.NoSpacesLeft())
                throw new Exception("You can't assign a piece to a full board");

            int randomIndex;
            while (true)
            {
                randomIndex = _random.Next(_boardSize);

                if (_boardCells.GetCell(randomIndex) == PieceType.Neither)
                    break;
            }
            _boardCells.SetCell(randomIndex, piece);

            var winner = _boardWinningRules.CheckForWinner(_boardCells);
            if (winner.HasValue)
                return winner.Value;

            if (_boardCells.NoSpacesLeft())
                return BoardStatus.Full;

            return BoardStatus.StillPlayable;
        }

        /// <summary>
        /// Render the board in text format - simple pass-thru to IBoardRenderer
        /// </summary>
        /// <returns>String with the formatted text of the board</returns>
        public string RenderAsText()
        {
            return _boardRenderer.RenderAsText(_boardCells);
        }

    }
}

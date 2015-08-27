using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPast.TicTacToe.Logic.Model
{
    internal class BoardCells : IBoardCells
    {
        /// <summary>
        /// Internal structure holding cell data
        /// </summary>
        /// <remarks>
        /// There are many collection types that could have been used - both linear (like this one) 
        /// or multi-dimensional (e.g 2D or jagged array). Despite the attractiveness of the latter, since
        /// it better represents a physical noughts-and-crosses board, the former was chosen since
        /// it made the code a lot cleaner
        /// 
        /// Another point was the structur of each cell. In a more complex game, we'd need a full blown
        /// object, but for a simple noughts-and-crosses game, a simple three-way enum is enough (KISS).
        /// </remarks>
        private readonly List<PieceType> _cells;

        private const int size = 9;


        public virtual void SetCell(int index, PieceType pieceType)
        {
            _cells[index] = pieceType;
        }

        public virtual PieceType GetCell(int index)
        {
            return _cells[index];
        }

        public virtual bool NoSpacesLeft()
        {
            return _cells.All(x => x != PieceType.Neither);
        }

        public virtual int Size()
        {
            return size;
        }


        public BoardCells()
        {
            _cells = Enumerable.Repeat(PieceType.Neither, size).ToList();
        }

    }
}

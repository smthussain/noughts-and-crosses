using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMyPast.TicTacToe.Logic.Model;
using Moq;

namespace FindMyPast.TicTacToe.Logic.Test
{
    class CommonMethods
    {
        public static Mock<IBoardCells> CreateMockBoardCells(string boardAsString)
        {
            if (boardAsString.Length != 9)
                throw new ArgumentException("There must be nine chars specified for a board", "boardAsString");

            var mockBoardCells = new Mock<IBoardCells>();

            var cells = boardAsString.ToCharArray().Select(x =>
            {
                if (x == 'O')
                    return PieceType.Nought;
                if (x == 'X')
                    return PieceType.Cross;
                if (x == ' ')
                    return PieceType.Neither;
                throw new Exception(x + " not recognised value for a board cell");
            }).ToList();

            mockBoardCells.Setup(x => x.GetCell(It.IsAny<int>())).Returns<int>(index => cells[index]);

            mockBoardCells.Setup(x => x.NoSpacesLeft()).Returns(cells.All(x => x != PieceType.Neither));

            mockBoardCells.Setup(x => x.Size()).Returns(9);

            return mockBoardCells;
        }
    }
}

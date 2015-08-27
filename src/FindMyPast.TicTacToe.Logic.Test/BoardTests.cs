using System;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using Autofac;
using FindMyPast.TicTacToe.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindMyPast.TicTacToe.Logic.Test
{
    /// <summary>
    /// Test placing pieces on a board and checking the status returned is as expected.
    /// Hopefully long test names are self-explanatory.
    /// 
    /// Used mock instances of IBoardCells and IBoardWinningRules
    /// </summary>
    [TestClass]
    public class BoardTests
    {
        private IBoard _board;
        private Mock<IBoardCells> _boardCells;
        private Mock<BoardWinningRules> _boardWinningRules;

        [TestMethod]
        public void PlacePieceOnBoardWithOneFreeSpace()
        {
            //arrange
            SetupBoard(
                "OXO" +
                "O X" +
                "XOO"
            );

            //act
            _board.AssignPieceToBoard(PieceType.Cross);

            //assert
            _boardCells.Verify(x => x.SetCell(4,PieceType.Cross));

        }

        /// <remarks>
        /// Inceidentally, which place is chosen should be random. Ideally we would somehow test this by say, 
        /// trying this test several times and showing a different placement. However, the non-deterministic
        /// nature of randomness makes it too brittle, IMHO, for an automated test
        /// </remarks>
        [TestMethod]
        public void PlacePieceOnBoardWithThreeFreeSpaces()
        {
            //arrange
            SetupBoard(
                "XO " +
                "OOX" +
                "  O"
            );

            //act
            _board.AssignPieceToBoard(PieceType.Cross);

            //assert
            _boardCells.Verify(x => x.SetCell(It.IsIn(new []{2,6,7}), PieceType.Cross));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PlacePieceOnFullBoard()
        {
            //arrange
            SetupBoard(
                "OXO" +
                "XXX" +
                "XXO"
            );

            //act
            _board.AssignPieceToBoard(PieceType.Cross);

            //assert - expect exception (see this methods attributes)
        }

        [TestMethod]
        public void WinnerIsShownOnPartialBoard()
        {
            //arrange
            SetupBoard();
            _boardWinningRules.Setup(x => x.CheckForWinner(It.IsAny<IBoardCells>())).Returns(BoardStatus.CrossesWins);
            _boardCells.Setup(x => x.NoSpacesLeft()).Returns(false);

            //act
            var status = _board.AssignPieceToBoard(PieceType.Cross);

            //assert
            Assert.AreEqual(BoardStatus.CrossesWins, status);
        }


        [TestMethod]
        public void WinnerIsShownOnFullBoard()
        {
            //arrange
            SetupBoard();
            _boardWinningRules.Setup(x => x.CheckForWinner(It.IsAny<IBoardCells>())).Returns(BoardStatus.NoughtsWins);
            _boardCells.SetupSequence(x => x.NoSpacesLeft())
                .Returns(false)
                .Returns(true); //full after piece placed

            //act
            var status = _board.AssignPieceToBoard(PieceType.Nought);

            //assert
            Assert.AreEqual(BoardStatus.NoughtsWins, status);
        }

        [TestMethod]
        public void FullBoardIsShownAsSuchWhenNoWinner()
        {
            //arrange
            SetupBoard();
            _boardWinningRules.Setup(x => x.CheckForWinner(It.IsAny<IBoardCells>())).Returns((BoardStatus?) null);

            _boardCells.SetupSequence(x => x.NoSpacesLeft())
                .Returns(false)
                .Returns(true); //board only full on second check (i.e. after piece is placed, not on first check)                                

            //act
            var status = _board.AssignPieceToBoard(PieceType.Nought);

            //assert
            Assert.AreEqual(BoardStatus.Full, status);
        }

        [TestMethod]
        public void WhenNoWinnerOnPartiallyFilledBoardThenShowAsStillPlayable()
        {
            //arrange
            SetupBoard();
            _boardWinningRules.Setup(x => x.CheckForWinner(It.IsAny<IBoardCells>())).Returns((BoardStatus?)null);
            _boardCells.Setup(x => x.NoSpacesLeft()).Returns(false);

            //act
            var status = _board.AssignPieceToBoard(PieceType.Nought);

            //assert
            Assert.AreEqual(BoardStatus.StillPlayable, status);
        }



        private void SetupBoard(string boardCellsAsString = "         ")
        {
            //create mocks for injecting into board

            _boardCells = CommonMethods.CreateMockBoardCells(boardCellsAsString);

            _boardWinningRules = new Mock<BoardWinningRules>();

            var builder = new ContainerBuilder();

            //register default concrete types with interface...
            builder.RegisterAssemblyTypes(typeof(IBoard).Assembly).AsImplementedInterfaces();

            //... and then override some defaults with mocks
            builder.RegisterInstance(_boardCells.Object).As<IBoardCells>();
            builder.RegisterInstance(_boardWinningRules.Object).As<IBoardWinningRules>();

            var container = builder.Build();

            _board = container.Resolve<IBoard>();
        }


    }
}

using Autofac;
using FindMyPast.TicTacToe.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindMyPast.TicTacToe.Logic.Test
{
    [TestClass]
    public class BoardWinningRulesTests
    {

        private IBoardWinningRules _boardWinningRules;

        [TestInitialize]
        public void SetUp()
        {
            _boardWinningRules = new BoardWinningRules();
        }

        [TestMethod]
        public void NoughtsWinHorizontallyOnCompleteBoard()
        {
            var cells = CommonMethods.CreateMockBoardCells(
                "OOO" +
                "XOX" +
                "XXO"
                );
            var status = _boardWinningRules.CheckForWinner(cells.Object);

            Assert.AreEqual(BoardStatus.NoughtsWins, status);
        }

        [TestMethod]
        public void NoughtsWinVerticallyOnIncompleteBoard()
        {
            var cells = CommonMethods.CreateMockBoardCells(
                "OOX" +
                "XOX" +
                " O "
                );
            var status = _boardWinningRules.CheckForWinner(cells.Object);

            Assert.AreEqual(BoardStatus.NoughtsWins, status);
        }

        [TestMethod]
        public void CrossesWinDiagonallyOnIncompleteBoard()
        {
            var cells = CommonMethods.CreateMockBoardCells(
                " OX" +
                "OXX" +
                "XOO"
                );
            var status = _boardWinningRules.CheckForWinner(cells.Object);

            Assert.AreEqual(BoardStatus.CrossesWins, status);
        }

        [TestMethod]
        public void NoOneWins()
        {
            var cells = CommonMethods.CreateMockBoardCells(
                "XOX" +
                "OOX" +
                "XXO"
                );
            var status = _boardWinningRules.CheckForWinner(cells.Object);

            Assert.IsNull(status);
        }

        
    }
}
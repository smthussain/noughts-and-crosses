using Autofac;
using FindMyPast.TicTacToe.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindMyPast.TicTacToe.Logic.Test
{
    [TestClass]
    public class BoardRendererTests
    {

        private IBoardRenderer _boardRenderer;

        [TestInitialize]
        public void SetUp()
        {
            _boardRenderer = new BoardRenderer();
        }

        [TestMethod]
        public void CheckRenderOfEmptyBoard()
        {
            const string cellsString = "   " +
                                       "   " +
                                       "   ";

            const string expectedRender = "   |   |   \n" +
                                          "-----------\n" +
                                          "   |   |   \n" +
                                          "-----------\n" +
                                          "   |   |   \n";

            var cells = CommonMethods.CreateMockBoardCells(cellsString);

            var actualRender = _boardRenderer.RenderAsText(cells.Object);

            Assert.AreEqual(expectedRender, actualRender);
        }
        [TestMethod]
        public void CheckRenderOfFullBoard()
        {
            const string cellsString = "OOO" +
                                       "XOX" +
                                       "XXO";

            const string expectedRender = " O | O | O \n" +
                                          "-----------\n" +
                                          " X | O | X \n" +
                                          "-----------\n" +
                                          " X | X | O \n";

            var cells = CommonMethods.CreateMockBoardCells(cellsString);

            var actualRender = _boardRenderer.RenderAsText(cells.Object);

            Assert.AreEqual(expectedRender, actualRender);
        }
        [TestMethod]
        public void CheckRenderOfPartialBoard()
        {
            const string cellsString = " OO" +
                                       "X  " +
                                       "XX ";

            const string expectedRender = "   | O | O \n" +
                                          "-----------\n" +
                                          " X |   |   \n" +
                                          "-----------\n" +
                                          " X | X |   \n";

            var cells = CommonMethods.CreateMockBoardCells(cellsString);

            var actualRender = _boardRenderer.RenderAsText(cells.Object);

            Assert.AreEqual(expectedRender, actualRender);
        }



        
    }
}
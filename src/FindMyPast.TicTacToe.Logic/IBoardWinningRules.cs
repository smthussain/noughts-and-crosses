using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// For a given set of cells, determines if it results in a winning position
    /// </summary>
    internal interface IBoardWinningRules
    {
        BoardStatus? CheckForWinner(IBoardCells boardCells);
    }
}
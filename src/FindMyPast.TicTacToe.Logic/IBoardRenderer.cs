using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// Renders the board. It could be argued this belongs in the UI
    /// However, kept here for better cohesion (with IBoardCells) and potentional
    /// re-use across other UIs
    /// </summary>
    internal interface IBoardRenderer
    {
        string RenderAsText(IBoardCells boardCells);
    }
}
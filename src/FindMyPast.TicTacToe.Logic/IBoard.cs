using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// This is the ONLY public entity in this assembly. It presents a clean interface (ISP) to do two things
    /// with a noughts and crosses board
    /// - take a turn (which return the status of the board - a simple enum acts of the status DTO)
    /// - render the board
    /// </summary>
    /// <remarks>
    /// It could be argued that the Rendering belongs in the UI. It's been kept here for simplicity and
    /// potential re-usability with other UIs
    /// </remarks>
    public interface IBoard
    {
        BoardStatus AssignPieceToBoard(PieceType piece);
        string RenderAsText();
    }
}
using System.Collections.ObjectModel;

namespace FindMyPast.TicTacToe.Logic.Model
{
    /// <summary>
    /// Encapsulates the actual storage of the board structure
    /// </summary>
    internal interface IBoardCells
    {
        void SetCell(int index, PieceType pieceType);
        PieceType GetCell(int index);
        bool NoSpacesLeft();
        int Size();
    }
}
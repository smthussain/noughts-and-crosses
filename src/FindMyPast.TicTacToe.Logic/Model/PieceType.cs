using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPast.TicTacToe.Logic.Model
{
    /// <remarks>
    /// For simplicity (at the expensive of some unwanted coupling), this enum is used for several purposes:
    /// 1) status of a cell on the board (where Neither means Empty)
    /// 2) the type of a piece (where Neither is n/a)
    /// </remarks>>
    public enum PieceType
    {
        Nought,
        Cross,
        Neither
    }
}

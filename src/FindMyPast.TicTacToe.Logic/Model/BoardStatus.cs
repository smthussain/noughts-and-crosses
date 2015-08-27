using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPast.TicTacToe.Logic.Model
{
    /// <summary>
    /// The status of a whole board 
    /// (for simplicity, also used with IBoardWinningRules for first NoughtsWins & CrossesWins only)
    /// </summary>
    public enum BoardStatus
    {
        NoughtsWins,
        CrossesWins,
        Full,
        StillPlayable
    }
}

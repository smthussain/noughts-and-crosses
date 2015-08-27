using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.Logic
{
    /// <summary>
    /// KISS and readability really win here - since noughts-and-crosses has such simple rules, 
    /// with only two players, nice positions and 8 winning combinations, the most
    /// readable way is a simple lookup of all combinations. For a more complex game (e.g. Connect 4),
    /// we'd have more complex analysis logic
    /// 
    /// SRP - if the rules change (e.g. you can have non-straight lines), only this class must change
    /// OCP - if the rules radically change, we just swap this class out with another that implements IBoardWinningRules
    /// </summary>
    internal class BoardWinningRules : IBoardWinningRules
    {
        //any array of just simple 3-element arrays is simple enough for lookup - no need for custom class
        private readonly int[][] _winningCombinations = 
            {
                //horizontals
                new[] {0, 1, 2},
                new[] {3, 4, 5},
                new[] {6, 7, 8},

                //verticals
                new[] {0, 3, 6},
                new[] {1, 4, 7},
                new[] {2, 5, 8},

                //diagonals
                new[] {0, 4, 8},
                new[] {2, 4, 6},
            };

        public virtual BoardStatus? CheckForWinner(IBoardCells boardCells)
        {
            foreach (var combination in _winningCombinations)
            {
                var firstCell = boardCells.GetCell(combination[0]);

                //if one cell of the combination is empty, it can't be part of a winning combination - move on
                if (firstCell == PieceType.Neither) continue;

                //if all three cells have the same non-empty value, we have a winner
                if (    
                        boardCells.GetCell(combination[1]) == firstCell
                            && 
                        boardCells.GetCell(combination[2]) == firstCell
                    )
                {
                    return firstCell == PieceType.Nought
                        ? BoardStatus.NoughtsWins
                        : BoardStatus.CrossesWins;                    
                }

            }

            //no winning combination found
            return null;

        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 794
    /// title:  有效的井字游戏
    /// problems: https://leetcode-cn.com/problems/valid-tic-tac-toe-state/
    /// date: 20211209
    /// </summary>
    public static class Solution794
    {
        public static bool ValidTicTacToe(string[] board) {
            bool Win(char p) {
                for (int i = 0; i < 3; ++i) {
                    if (p == board[i][0] && p == board[i][1] && p == board[i][2]) 
                        return true;
                    
                    if (p == board[0][i] && p == board[1][i] && p == board[2][i]) 
                        return true;
                }

                if (p == board[0][0] && p == board[1][1] && p == board[2][2]) 
                    return true;
                
                if (p == board[0][2] && p == board[1][1] && p == board[2][0])
                    return true;
                
                return false;
            }

            int xCount = 0, oCount = 0;

            foreach (string row in board) {
                foreach (char c in row) {
                    xCount = (c == 'X') ? (xCount + 1) : xCount;
                    oCount = (c == 'O') ? (oCount + 1) : oCount;
                }
            }

            if (oCount != xCount && oCount != xCount - 1) 
                return false;
            
            if (Win('X') && oCount != xCount - 1)
                return false;
            
            if (Win('O') && oCount != xCount)
                return false;
            
            return true;
        }
    }
}
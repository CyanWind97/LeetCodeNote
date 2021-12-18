namespace LeetCodeNote
{
    /// <summary>
    /// no: 419
    /// title: 甲板上的战舰
    /// problems: https://leetcode-cn.com/problems/battleships-in-a-board/
    /// date: 20211218
    /// </summary>
    public static class Solution419
    {
        public static int CountBattleships(char[][] board) {
            int m = board.Length;
            int n = board[0].Length;
            int result = 0;
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (board[i][j] == 'X') {
                        if (i > 0 && board[i - 1][j] == 'X') 
                            continue;
                        
                        if (j > 0 && board[i][j - 1] == 'X') 
                            continue;
                        
                        result++;
                    }
                }
            }
            
            return result;
        }
    }
}
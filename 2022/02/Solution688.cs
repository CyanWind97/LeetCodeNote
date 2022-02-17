namespace LeetCodeNote1
{
    /// <summary>
    /// no: 688
    /// title: 骑士在棋盘上的概率
    /// problems: https://leetcode-cn.com/problems/knight-probability-in-chessboard/
    /// date: 20220217
    /// </summary>
    public static class Solution688
    {
        // 参考解答 dp
        public static double KnightProbability(int n, int k, int row, int column) {
            int[][] dirs = {new int[]{-2, -1}, new int[]{-2, 1}, new int[]{2, -1}, new int[]{2, 1}, new int[]{-1, -2}, new int[]{-1, 2}, new int[]{1, -2}, new int[]{1, 2}};
            
            double[,,] dp = new double[k + 1, n, n];
            for (int step = 0; step <= k; step++) {
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        if (step == 0) {
                            dp[step, i, j] = 1;
                        } else {
                            foreach (int[] dir in dirs) {
                                int r = i + dir[0], c = j + dir[1];
                                if (r >= 0 && r < n && c >= 0 && c < n) 
                                    dp[step, i, j] += dp[step - 1, r, c] / 8;
                                
                            }
                        }
                    }
                }
            }
            
            return dp[k, row, column];
        }
    }
}
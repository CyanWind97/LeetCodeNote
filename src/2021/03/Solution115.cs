namespace LeetCodeNote
{
    /// <summary>
    /// no: 115
    /// title: 不同的子序列
    /// problems: https://leetcode-cn.com/problems/distinct-subsequences/
    /// date: 20210317
    /// </summary>
    public static class Solution115
    {

        // 参考解答 动态规划 记忆搜索
        public static int NumDistinct(string s, string t) {
            int m = s.Length;
            int n = t.Length;
            if(m < n)
                return 0;
            
            int[,] dp = new int[m + 1, n + 1];
            for(int i = 0; i <= m; i++){
                dp[i, n] = 1;
            }

            for(int i = m - 1; i >= 0; i--){
                char c = s[i];
                for(int j = n - 1; j >= 0; j--){
                    if(c == t[j])
                        dp[i , j] = dp[i + 1, j + 1] + dp[i + 1 , j];
                    else
                        dp[i , j] = dp[i + 1, j]; 
                }
            }

            return dp[0, 0];
        }
    }
}
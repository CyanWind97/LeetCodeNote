namespace LeetCodeNote
{
    /// <summary>
    /// no: 07
    /// title: 传递信息
    /// problems: https://leetcode-cn.com/problems/chuan-di-xin-xi/
    /// date: 20210701
    /// type: lcp
    /// </summary>
    public static class Solution_lcp_07
    {
        public static int NumWays(int n, int[][] relation, int k) {
            int[] dp = new int[n];
            dp[0] = 1;
            for(int i = 0; i < k; i++){
                int[] tmp = new int[n];
                foreach(var pair in relation){
                    tmp[pair[1]] += dp[pair[0]];
                }
                dp = tmp;
            }

            return dp[n - 1];
        }
    }
}
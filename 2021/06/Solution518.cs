namespace LeetCodeNote
{
    /// <summary>
    /// no: 518
    /// title: 零钱兑换 II
    /// problems: https://leetcode-cn.com/problems/coin-change-2/
    /// date: 20210610
    /// </summary>
    public static class Solution518
    {
        public static int Change(int amount, int[] coins) {
            int length = coins.Length;
            int[] dp = new int[amount + 1];

            dp[0] = 1;

            foreach(var coin in coins){
                for(int i = coin; i <= amount; i++){
                    dp[i] = dp[i] + dp[i - coin];
                }
            }

            return dp[amount];
        }
    }
}
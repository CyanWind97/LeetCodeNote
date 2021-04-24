namespace LeetCodeNote
{
    /// <summary>
    /// no: 377
    /// title: 组合总和 Ⅳ
    /// problems: https://leetcode-cn.com/problems/combination-sum-iv/
    /// date: 20210424
    /// </summary>
    public static class Solution377
    {
        
        public static int CombinationSum4(int[] nums, int target) {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            for(int i = 1; i <= target; i++){
                foreach(int num in nums){
                    if(num <= i)
                        dp[i] += dp[i - num];
                }
            }

            return dp[target];
        }
    }
}
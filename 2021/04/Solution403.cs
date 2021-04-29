namespace LeetCodeNote
{
    /// <summary>
    /// no: 403
    /// title: 青蛙过河
    /// problems: https://leetcode-cn.com/problems/frog-jump/
    /// date: 20210429
    /// </summary>
    public static class Solution403
    {
        // 参考解答 动态规划
        public static bool CanCross(int[] stones) {
            int length = stones.Length;
            
            bool[,] dp = new bool[length, length];
            dp[0, 0] = true;
            for(int i = 1; i < length; i++){
                if(stones[i] - stones[i - 1] > i)
                    return false;
            }

            for(int i = 1; i < length; i++){
                for(int j = i - 1; j >= 0; j--){
                    int k = stones[i] - stones[j];
                    if(k > j + 1)
                        break;
                    
                    dp[i,k] = dp[j, k - 1] || dp[j,k] || dp[j, k + 1];
                    if(i == length - 1 && dp[i, k])
                        return true;
                }
            }

            return false;
        }
    }
}
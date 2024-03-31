using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1690
    /// title: 石子游戏 VII
    /// problems: https://leetcode.cn/problems/stone-game-vii/description/?envType=daily-question&envId=2024-02-03
    /// date: 20240203
    /// </summary>
    public static class Solution1690
    {
        public static int StoneGameVII(int[] stones) {
            int n = stones.Length;
            var sum = new int[n + 1];
            var dp = new int[n, n];

            for (int i = 0; i < n; i++) {
                sum[i + 1] = sum[i] + stones[i];
            }
            for (int i = n - 2; i >= 0; i--) {
                for (int j = i + 1; j < n; j++) {
                    dp[i, j] = Math.Max(sum[j + 1] - sum[i + 1] - dp[i + 1, j], sum[j] - sum[i] - dp[i, j - 1]);
                }
            }

            return dp[0, n - 1];
        }
        
        // 错误猜想
        public static int StoneGameVII_1(int[] stones) {
            int n = stones.Length;
            bool isOdd = n % 2 == 1;
            
            int left = 0;
            int right = n - 1;

            int result = 0; 
            bool isAlice = true;

            int RemoveNum(){
                int remove = 0;
                if (left == right){
                    remove = stones[left];
                    left++;

                    return remove;
                }

                int leftSum = stones[left] + stones[right - 1];
                int rightSum = stones[right] + stones[left + 1];

                bool removeLeft = leftSum < rightSum
                            || leftSum == rightSum && stones[left] < stones[right];
                
                if(!isOdd)
                    removeLeft = !removeLeft;
                
                if(removeLeft){
                    remove = stones[left];
                    left++;
                }else{
                    remove = stones[right];
                    right--;
                }
                
                return remove;
            }

            while(left < right){
                var remove = RemoveNum();
                if (!isAlice)
                    result += remove;
                
                isAlice = !isAlice;
            }

            return result;
    }
    }
}
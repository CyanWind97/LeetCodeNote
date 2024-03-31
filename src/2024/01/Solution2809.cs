using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2809
    /// title: 使数组和小于等于 x 的最少时间
    /// problems: https://leetcode.cn/problems/minimum-time-to-make-array-sum-at-most-x/description/?envType=daily-question&envId=2024-01-19
    /// date: 20240119
    /// </summary>
    public static class Solution2809
    {
        // 参考解答
        // dp
        public static int MinimumTime(IList<int> nums1, IList<int> nums2, int x) {
            var length = nums1.Count;
            var dp = new int[length + 1];
            int sum1 = 0;
            int sum2 = 0;

            var nums = new List<(int First, int Second)>();
            for(int i = 0; i < length; i++){
                nums.Add((nums1[i], nums2[i]));
                sum1 += nums1[i];
                sum2 += nums2[i];
            }

            nums.Sort((a, b) => (a.Second - b.Second));
            
            for(int j = 1; j <= length; j++){
                (int a, int b) = nums[j - 1];
                for(int i = j; i > 0; --i){
                    dp[i] = Math.Max(dp[i], dp[i - 1] + i * b + a);
                }
            }

            for(int i = 0; i <= length; i++){
                if(sum2 * i + sum1 - dp[i] <= x)
                    return i;
            }

            return -1;
        }
    }
}
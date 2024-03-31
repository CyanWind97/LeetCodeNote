using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1658
    /// title: 将 x 减到 0 的最小操作数
    /// problems: https://leetcode.cn/problems/minimum-operations-to-reduce-x-to-zero/
    /// date: 20230107
    /// </summary>
    public static class Solution1658
    {
        // 参考解答
        // 滑动窗口 + 前缀和 + 后缀和
        public static int MinOperations(int[] nums, int x) {
            int n = nums.Length;
            int sum = nums.Sum();
            if(sum < x)
                return -1;
            
            int right = 0;
            int lsum = 0;   // 前缀和
            int rsum = sum; // 后缀和
            int result = n + 1;

            for(int left = -1; left < n; left++){
                if(left != -1)
                    lsum += nums[left];
                
                while(right < n && lsum + rsum > x){
                    rsum -= nums[right];
                    ++right;
                }

                if(lsum + rsum == x)
                    result = Math.Min(result, (left + 1) + (n - right));
            }

            return result > n ? -1 : result;
        }
    }
}
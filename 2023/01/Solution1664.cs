using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1664
    /// title: 生成平衡数组的方案数
    /// problems: https://leetcode.cn/problems/ways-to-make-a-fair-array/
    /// date: 20230128
    /// </summary>
    public static class Solution1664
    {
        // 参考解答
        // 动态规划
        public static int WaysToMakeFair(int[] nums) {
            int s = 0;

            int n = nums.Length;
            for(int i = 0; i < n; i++){
                s += i % 2 == 0 ? -nums[i] : nums[i];
            }
            
            int result = 0;
            for(int i = 0; i < n; i++){
                s += i % 2 == 0 ? nums[i] : -nums[i];
                
                if(s == 0)
                    result++;
                
                s += i % 2 == 0 ? nums[i] : -nums[i];
            }

            return result;
        }
    }
}
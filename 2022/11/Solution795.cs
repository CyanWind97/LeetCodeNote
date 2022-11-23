using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 795
    /// title: 区间子数组个数
    /// problems: https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/
    /// date: 20221124
    /// </summary>
    public static class Solution795
    {
        public static int NumSubarrayBoundedMax(int[] nums, int left, int right) {
           int Count(int lower) {
                int result = 0;
                int cur = 0;
                foreach (int x in nums) {
                    cur = x <= lower ? cur + 1 : 0;
                    result += cur;
                }

                return result;
            }

            return Count(right) - Count(left - 1);
        }
    }
}
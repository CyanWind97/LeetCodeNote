using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2389
    /// title: 和有限的最长子序列
    /// problems: https://leetcode.cn/problems/longest-subsequence-with-limited-sum/
    /// date: 20230317
    /// </summary>
    public static class Solution2389
    {
        public static int[] AnswerQueries(int[] nums, int[] queries) {
            Array.Sort(nums);
            int n = nums.Length;
            var sums = new int[n + 1];
            for(int i = 0; i < n; i++){
                sums[i + 1] = sums[i] + nums[i];
            }

            int m = queries.Length;
            var result = new int[m];
            for(int i = 0; i < m; i++){
                int index = Array.BinarySearch(sums, queries[i]);
                if(index < 0)
                    index = ~index;
                else
                    index++;

                result[i] = index - 1;
            }

            return result;
        }
    }
}
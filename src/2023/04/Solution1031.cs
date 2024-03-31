using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1031
    /// title: 两个非重叠子数组的最大和
    /// problems: https://leetcode.cn/problems/maximum-sum-of-two-non-overlapping-subarrays/
    /// date: 20230426
    /// </summary>
    public static class Solution1031
    {
        // 参考解答
        // 滑档窗口
        public static int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen) {
            int Help(int l1, int l2) {
                int suml = 0;
                for (int i = 0; i < l1; ++i) {
                    suml += nums[i];
                }
                int maxSumL = suml;
                int sumr = 0;
                for (int i = l1; i < l1 + l2; ++i) {
                    sumr += nums[i];
                }
                int res = maxSumL + sumr;
                for (int i = l1 + l2, j = l1; i < nums.Length; ++i, ++j) {
                    suml += nums[j] - nums[j - l1];
                    maxSumL = Math.Max(maxSumL, suml);
                    sumr += nums[i] - nums[i - l2];
                    res = Math.Max(res, maxSumL + sumr);
                }
                return res;
            }

            return Math.Max(Help(firstLen, secondLen), Help(secondLen, firstLen));
        }
    }
}
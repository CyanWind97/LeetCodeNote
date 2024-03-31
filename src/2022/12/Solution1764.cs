using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1764
    /// title:  通过连接另一个数组的子数组得到一个数组
    /// problems: https://leetcode.cn/problems/form-array-by-concatenating-subarrays-of-another-array/
    /// date: 20221217
    /// </summary>
    public static class Solution1764
    {
        // 参考解答
        // 贪心 + 双指针
        public static bool CanChoose(int[][] groups, int[] nums) {
            bool Check(int[] g, int k) {
                if (k + g.Length > nums.Length) {
                    return false;
                }
                for (int j = 0; j < g.Length; j++) {
                    if (g[j] != nums[k + j]) {
                        return false;
                    }
                }
                return true;
            }

            int i = 0;
            for (int k = 0; k < nums.Length && i < groups.Length;) {
                if (Check(groups[i], k)) {
                    k += groups[i].Length;
                    i++;
                } else {
                    k++;
                }
            }
            return i == groups.Length;
        }
    }
}
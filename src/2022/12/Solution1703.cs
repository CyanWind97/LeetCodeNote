using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1703
    /// title:  得到连续 K 个 1 的最少相邻交换次数
    /// problems: https://leetcode.cn/problems/minimum-adjacent-swaps-for-k-consecutive-ones/
    /// date: 20221218
    /// </summary>
    public static class Solution1703
    {
        // 参考解答
        // 滑动窗口
        public static int MinMoves(int[] nums, int k) {
            int n = nums.Length;
            var pos = new int[n];
            int index = 0;
            for(int i = 0; i < n; i++){
                if(nums[i] == 1)
                    pos[index++] = i;
            }

            int result = 0; 
            int count = 0;
            int mid = k / 2;

            for(int i = 1; i < k; i++){
                count += (pos[i] - pos[i - 1] - 1) * Math.Min(i, k - i);
            }

            result = count;

            for(int i = k; i < index; i++){
                count -= pos[i - k + mid] - pos[i - k];
                count += pos[i] - pos[i - mid];
                result = Math.Min(result, count);
            }

            return result;
        }
    }
}
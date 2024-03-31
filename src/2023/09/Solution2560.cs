using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2560
    /// title: 打家劫舍 IV
    /// problems: https://leetcode.cn/problems/house-robber-iv/?envType=daily-question&envId=2023-09-19
    /// date: 20230919
    /// </summary>
    public static class Solution2560
    {
        // 参考解答
        // 二分查找
        public static int MinCapability(int[] nums, int k) {
            int lower = nums.Min();
            int upper = nums.Max();
            while (lower <= upper) {
                int middle = (lower + upper) / 2;
                int count = 0;
                bool visited = false;
                foreach (int x in nums) {
                    if (x <= middle && !visited) {
                        count++;
                        visited = true;
                    } else {
                        visited = false;
                    }
                }
                if (count >= k) {
                    upper = middle - 1;
                } else {
                    lower = middle + 1;
                }
            }

            return lower;
        }
    }
}
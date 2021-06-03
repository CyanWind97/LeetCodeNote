using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 525
    /// title: 连续数组
    /// problems: https://leetcode-cn.com/problems/contiguous-array/
    /// date: 20210603
    /// </summary>
    public static class Solution525
    {
        public static int FindMaxLength(int[] nums) {
            int length = nums.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int count = 0;
            dic.Add(count, -1);

            int max = 0;
            for (int i = 0; i < length; i++) {
                int num = nums[i];
                if (num == 1)
                    count++;
                else
                    count--;
                
                if (dic.ContainsKey(count)) {
                    int pre = dic[count];
                    max = Math.Max(max, i - pre);
                } else {
                    dic.Add(count, i);
                }
            }

            return max;
        }
    }
}

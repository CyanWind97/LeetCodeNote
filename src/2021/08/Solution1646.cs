using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1646
    /// title:  获取生成数组中的最大值
    /// problems: https://leetcode-cn.com/problems/get-maximum-in-generated-array/
    /// date: 20210823
    /// </summary>
    public static class Solution1646
    {
        public static int GetMaximumGenerated(int n)
        {
            if (n == 0)
                return 0;

            int max = 1;
            int[] nums = new int[n + 1];
            nums[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                int x = i / 2;
                nums[i] = nums[x];
                if (2 * x < i)
                {
                    nums[i] += nums[x + 1];
                    max = Math.Max(nums[i], max);
                }
            }

            return max;
        }

        // 打表
        public static int GetMaximumGenerated_1(int n)
        {
            int[] result = new int[]{0,1,1,2,2,3,3,3,3,4,4,5,5,5,5,5,5,5,5,7,7,8,8,8,8,8,8,8,8,8,8,8,8,8,8,9,9,11,11,11,11,11,11,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,15,15,18,18,18,18,18,18,18,18,19,19,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21};
            return result[n];
        }

    }
}
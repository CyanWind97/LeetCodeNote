using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2044
    /// title: 统计按位或能得到最大值的子集数目
    /// problems: https://leetcode-cn.com/problems/count-number-of-maximum-bitwise-or-subsets/
    /// date: 20220315
    /// </summary>
    public static class Solution2044
    {
        public static int CountMaxOrSubsets(int[] nums) {
            int length = nums.Length;
            int maxOr = 0, count = 0;
            for (int i = 0; i < 1 << length; i++) {
                int orVal = 0;
                for (int j = 0; j < length; j++) {
                    if (((i >> j) & 1) == 1) 
                        orVal |= nums[j];
                }

                if (orVal > maxOr) {
                    maxOr = orVal;
                    count = 1;
                } else if (orVal == maxOr) {
                    count++;
                }
            }

            return count;
        }

        public static int CountMaxOrSubsets_1(int[] nums) {
            int length = nums.Length;
            int maxOr = 0;
            int count = 0;
            
            void DFS(int pos, int orVal){
                if (pos == length) {
                    if (orVal > maxOr) {
                        maxOr = orVal;
                        count = 1;
                    } else if (orVal == maxOr) {
                        count++;
                    }

                    return;
                }

                DFS(pos + 1, orVal | nums[pos]);
                DFS(pos + 1, orVal);
            }

            DFS(0, 0);

            return count;
        }
    }
}
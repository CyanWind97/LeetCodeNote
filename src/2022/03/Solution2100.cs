using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2100
    /// title: 适合打劫银行的日子
    /// problems: https://leetcode-cn.com/problems/find-good-days-to-rob-the-bank//
    /// date: 20220306
    /// </summary>
    public static class Solution2100
    {
        public static IList<int> GoodDaysToRobBank(int[] security, int time) {
            int length = security.Length;
            int[] left = new int[length];
            int[] right = new int[length];
            for (int i = 1; i < length; i++) {
                if (security[i] <= security[i - 1]) {
                    left[i] = left[i - 1] + 1;
                }
                if (security[length - i - 1] <= security[length - i]) {
                    right[length - i - 1] = right[length - i] + 1;
                }
            }

            IList<int> result = new List<int>();
            for (int i = time; i < length - time; i++) {
                if (left[i] >= time && right[i] >= time) {
                    result.Add(i);    
                }
            }
            return result;
        }
    }
}
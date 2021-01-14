using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1018
    /// title: 可被 5 整除的二进制前缀
    /// problems: https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/
    /// date: 20210114
    /// </summary>
    public static class Solution1018
    {
        public static IList<bool> PrefixesDivBy5(int[] A) {
            int length = A.Length;
            var ans = new List<bool>(length);
            int pre = 0;
            for(int i = 0; i < length; i++){
                pre = ((pre << 1) + A[i]) % 5;
                ans.Add(pre == 0);
            }

            return ans;
        }
    }
}
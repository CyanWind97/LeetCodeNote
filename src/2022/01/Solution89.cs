using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 89
    /// title: 格雷编码
    /// problems: https://leetcode-cn.com/problems/gray-code/
    /// date: 20220108
    /// </summary>
    public static class Solution89
    {
        public static IList<int> GrayCode(int n) {
            var ret = new List<int>();
            for (int i = 0; i < 1 << n; i++) {
                ret.Add((i >> 1) ^ i);
            }
            return ret;
        }
    }
}
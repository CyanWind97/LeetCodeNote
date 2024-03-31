using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 89
    /// title:  格雷编码
    /// problems: https://leetcode.cn/problems/gray-code/
    /// date: 20220517
    /// priority: 0074
    /// time: 00:25:58.06 timeout
    public static class CodeTop89
    {
        // 参考解答
        public static IList<int> GrayCode(int n) {
            var result = new int[1 << n];
            for (int i = 0; i < 1 << n; i++) {
                result[i] = (i >> 1) ^ i;
            }

            return result;
        }
    }
}
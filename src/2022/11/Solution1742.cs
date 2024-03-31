using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 878
    /// title: 第 N 个神奇数字
    /// problems: https://leetcode.cn/problems/nth-magical-number/
    /// date: 20221123
    /// </summary>
    public static class Solution1742
    {
        public static int CountBalls(int lowLimit, int highLimit) {
            var count = new Dictionary<int, int>();
            int res = 0;
            for (int i = lowLimit; i <= highLimit; i++) {
                int box = 0, x = i;
                while (x != 0) {
                    box += x % 10;
                    x /= 10;
                }
                count.TryAdd(box, 0);
                count[box]++;
                res = Math.Max(res, count[box]);
            }
            return res;
        }
    }
}
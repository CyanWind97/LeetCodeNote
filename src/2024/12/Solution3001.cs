using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3001
/// title: 捕获黑皇后需要的最少移动次数
/// problems: https://leetcode.cn/problems/check-if-two-chessboard-squares-have-the-same-color
/// date: 20241205
/// </summary>
public class Solution3001
{
    public static int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f) {
         // 车与皇后处在同一行，且中间没有象
        if (a == e && (c != a || d <= Math.Min(b, f) || d >= Math.Max(b, f))) {
            return 1;
        }
        // 车与皇后处在同一列，且中间没有象
        if (b == f && (d != b || c <= Math.Min(a, e) || c >= Math.Max(a, e))) {
            return 1;
        }
        // 象、皇后处在同一条对角线，且中间没有车
        if (Math.Abs(c - e) == Math.Abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) 
            || a < Math.Min(c, e) || a > Math.Max(c, e))) {
            return 1;
        }
        return 2;

    }
}

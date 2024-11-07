using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3255
/// title: 长度为 K 的子数组的能量值 II
/// problems: https://leetcode.cn/problems/find-the-power-of-k-size-subarrays-ii
/// date: 20241107
/// </summary>
public static class Solution3235
{
    // 参考解答
    public static bool CanReachCorner(int xCorner, int yCorner, int[][] circles) {
        bool[] visited = new bool[circles.Length];
        for (int i = 0; i < circles.Length; i++) {
            int[] circle = circles[i];
            int x = circle[0], y = circle[1], r = circle[2];
            if (PointInCircle(0, 0, x, y, r) || PointInCircle(xCorner, yCorner, x, y, r)) {
                return false;
            }
            if (!visited[i] && CircleIntersectsTopLeftOfRectangle(x, y, r, xCorner, yCorner) 
                && Dfs(i, circles, xCorner, yCorner, visited)) {
                return false;
            }
        }
        return true;
    }

    private static bool Dfs(int i, int[][] circles, int xCorner, int yCorner, bool[] visited) {
        int x1 = circles[i][0], y1 = circles[i][1], r1 = circles[i][2];
        if (CircleIntersectsBottomRightOfRectangle(x1, y1, r1, xCorner, yCorner)) {
            return true;
        }
        visited[i] = true;
        for (int j = 0; j < circles.Length; j++) {
            if (!visited[j]) {
                int x2 = circles[j][0], y2 = circles[j][1], r2 = circles[j][2];
                if (CirclesIntersectInRectangle(x1, y1, r1, x2, y2, r2, xCorner, yCorner) 
                    && Dfs(j, circles, xCorner, yCorner, visited)) {
                    return true;
                }
            }
        }
        return false;
    }

    private static bool PointInCircle(long px, long py, long x, long y, long r) {
        return (x - px) * (x - px) + (y - py) * (y - py) <= r * r;
    }

    private static bool CircleIntersectsTopLeftOfRectangle(int x, int y, int r, int xCorner, int yCorner) {
        return (Math.Abs(x) <= r && 0 <= y && y <= yCorner) ||
               (0 <= x && x <= xCorner && Math.Abs(y - yCorner) <= r) ||
               PointInCircle(x, y, 0, yCorner, r);
    }

    private static bool CircleIntersectsBottomRightOfRectangle(int x, int y, int r, int xCorner, int yCorner) {
        return (Math.Abs(y) <= r && 0 <= x && x <= xCorner) ||
               (0 <= y && y <= yCorner && Math.Abs(x - xCorner) <= r) ||
               PointInCircle(x, y, xCorner, 0, r);
    }

    private static bool CirclesIntersectInRectangle(long x1, long y1, long r1, long x2, long y2, long r2, long xCorner, long yCorner) {
        return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) <= (r1 + r2) * (r1 + r2) &&
               x1 * r2 + x2 * r1 < (r1 + r2) * xCorner &&
               y1 * r2 + y2 * r1 < (r1 + r2) * yCorner;
    }

}

using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 149
    /// title: 直线上最多的点数
    /// problems: https://leetcode-cn.com/problems/max-points-on-a-line/
    /// date: 20210624
    /// </summary>
    public static class Solution149
    {
        // 参考解答  哈希表
        public static int MaxPoints(int[][] points) {
            int gcd(int a, int b) => b != 0 ? gcd(b, a % b) : a;

            int n = points.Length;
            if (n <= 2) {
                return n;
            }
            int ret = 0;
            for (int i = 0; i < n; i++) {
                if (ret >= n - i || ret > n / 2) {
                    break;
                }
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                for (int j = i + 1; j < n; j++) {
                    int x = points[i][0] - points[j][0];
                    int y = points[i][1] - points[j][1];
                    if (x == 0) {
                        y = 1;
                    } else if (y == 0) {
                        x = 1;
                    } else {
                        if (y < 0) {
                            x = -x;
                            y = -y;
                        }
                        int gcdXY = gcd(Math.Abs(x), Math.Abs(y));
                        x /= gcdXY;
                        y /= gcdXY;
                    }
                    int key = y + x * 20001;
                    if (!dictionary.ContainsKey(key)) {
                        dictionary.Add(key, 1);
                    } else {
                        dictionary[key]++;
                    }
                }
                int maxn = 0;
                foreach (int num in dictionary.Values) {
                    maxn = Math.Max(maxn, num + 1);
                }
                ret = Math.Max(ret, maxn);
            }
            return ret;
        }
    }
}
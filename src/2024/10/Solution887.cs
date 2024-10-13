using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1884
/// title: 鸡蛋掉落
/// problems: https://leetcode.cn/problems/super-egg-drop
/// date: 20241014
/// </summary>
public static class Solution887
{
    // 参考解答
    public static int SuperEggDrop(int k, int n) {
        if (n == 1)
            return 1;

        var f = new int[n + 1,k + 1];
        for (int i = 1; i <= k; ++i) {
            f[1,i] = 1;
        }
        int ans = -1;
        for (int i = 2; i <= n; ++i) {
            for (int j = 1; j <= k; ++j) {
                f[i,j] = 1 + f[i - 1,j - 1] + f[i - 1,j];
            }
            if (f[i,k] >= n) {
                ans = i;
                break;
            }
        }
        return ans;
    }
}

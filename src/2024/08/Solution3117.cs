using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3117
/// title: 划分数组得到最小的值之和
/// problems: https://leetcode.cn/problems/minimum-sum-of-values-by-dividing-array
/// date: 20240816
/// </summary>
public static class Solution3117
{
    // 参考解答
    public static int MinimumValueSum(int[] nums, int[] andValues) {
        (int n, int m) = (nums.Length, andValues.Length);
        var memo = Enumerable.Range(0, m * n)
                    .Select(_ => new Dictionary<int, int>())
                    .ToArray();

        const int INF = (1 << 20) - 1;
        int DFS(int i, int j,  int curr){
            int key = i * m + j;
            if (i == n && j == m)
                return 0;
            
            if (i == n || j == m)
                return INF;

            if (memo[key].TryGetValue(curr, out int value))
                return value;
            
            curr &= nums[i];
            if ((curr & andValues[j]) < andValues[j])
                return INF;
            
            int result = DFS(i + 1, j, curr);
            if (curr == andValues[j])
                result = Math.Min(result, DFS(i + 1, j + 1, INF) + nums[i]);

            memo[key][curr] = result;
            return result;
        }

        int result = DFS(0, 0, INF);
        return result < INF ? result : -1;
    }
}

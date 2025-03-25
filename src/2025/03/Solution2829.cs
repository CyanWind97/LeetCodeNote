using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2829
/// title:  k-avoiding 数组的最小总和
/// problems: https://leetcode.cn/problems/determine-the-minimum-sum-of-a-k-avoiding-array
/// date: 20250326
/// </summary>
public static class Solution2829
{
    public static int MinimumSum(int n, int k) {
        // 用于存储已选的数字
        HashSet<int> set = new HashSet<int>();
        int sum = 0;
        
        // 从1开始尝试选取数字
        for (int i = 1; set.Count < n; i++) {
            // 如果 k-i 不在集合中，则可以选择 i
            // 或者如果 i 已经大于等于 k，则 k-i 一定小于等于0，不会在集合中
            if (i >= k || !set.Contains(k - i)) {
                set.Add(i);
                sum += i;
            }
        }
        
        return sum;
    }
}

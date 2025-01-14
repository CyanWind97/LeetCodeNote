using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3066
/// title: 超过阈值的最少操作数 II
/// problems: https://leetcode.cn/problems/minimum-operations-to-exceed-threshold-value-ii
/// date: 20250115
/// </summary>
public static class Solution3066
{
    public static int MinOperations(int[] nums, int k) {
        int result = 0;
        var pq = new PriorityQueue<long, long>();
        foreach (int num in nums) {
            pq.Enqueue(num, num);
        }
        while (pq.Peek() < k) {
            long x = pq.Dequeue(), y = pq.Dequeue();
            pq.Enqueue(x + x + y, x + x + y);
            result++;
        }

        return result;
    }
}

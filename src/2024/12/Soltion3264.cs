using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3264
/// title: K 次乘运算后的最终数组 I
/// problems: https://leetcode.cn/problems/final-array-state-after-k-multiplication-operations-i
/// date: 20241213
/// </summary>
public static class Soltion3264
{
    public static int[] GetFinalState(int[] nums, int k, int multiplier) {
        if (multiplier == 1)
            return nums;

        int length = nums.Length;
        var pq = new PriorityQueue<int, (int Value, int Index)>(
            Comparer<(int Value, int Index)>.Create((a, b) =>
                a.Value == b.Value ? a.Index - b.Index : a.Value - b.Value
        ));
        
        for (int i = 0; i < length; i++){
            pq.Enqueue(i, (nums[i], i));
        }

        for (int i = 0; i < k; i++){
            var index = pq.Dequeue();
            nums[index] *= multiplier;
            pq.Enqueue(index, (nums[index], index));
        }

        return nums;
    }
}

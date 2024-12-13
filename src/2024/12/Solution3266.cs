using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3266
/// title: K 次乘运算后的最终数组 II
/// problems: https://leetcode.cn/problems/final-array-state-after-k-multiplication-operations-ii/description/?envType=daily-question&envId=2024-12-14
/// date: 20241214
/// </summary>
public class Solution3266
{
    // 参考解答
    public static int[] GetFinalState(int[] nums, int k, int multiplier) {
        if (multiplier == 1)
            return nums;

        const int MOD = 1_000_000_007;
        int length = nums.Length;
        var pq = new PriorityQueue<(long Value, int Index), (long Value, int Index)>(
            Comparer<(long Value, int Index)>.Create((a, b) =>
                a.Value == b.Value 
                ? a.Index.CompareTo(b.Index)
                : a.Value.CompareTo(b.Value)
        ));
        
        int max = 0;
        for (int i = 0; i < length; i++){
            max = Math.Max(max, nums[i]);
            pq.Enqueue((nums[i], i), (nums[i], i));
        }

        for (; nums[pq.Peek().Index] < max && k > 0; k--){
            var (value, index) = pq.Dequeue();
            value *= multiplier;
            pq.Enqueue((value, index), (value, index));
        }

        for (int i = 0; i < length; i++){
            var (value, index) = pq.Dequeue();
            var t = k / length + (i < k % length ? 1 : 0);
            nums[index] = (int)((long)(value % MOD) * (long)BigInteger.ModPow(multiplier, t, MOD) % MOD);
            
        }

        return nums;
    }
}

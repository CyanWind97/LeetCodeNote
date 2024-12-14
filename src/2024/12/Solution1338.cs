using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1338
/// title: 数组大小减半
/// problems: https://leetcode.cn/problems/reduce-array-size-to-the-half
/// date: 20241215
/// </summary>
public static class Solution1338
{
    public static int MinSetSize(int[] arr) {
        var count = new Dictionary<int, int>();
        int length = arr.Length;
        foreach (var num in arr){
            if (count.ContainsKey(num))
                count[num]++;
            else
                count[num] = 1;
        }

        var sorted = count.Values.OrderByDescending(x => x).ToArray();
        int half = length / 2;
        int result = 0;
        int sum = 0;
        for (int i = 0; i < sorted.Length; i++){
            sum += sorted[i];
            result++;
            if (sum >= half)
                break;
        }

        return result;
    }
}

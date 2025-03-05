using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 2588
/// title: 统计美丽子数组数目
/// problems: https://leetcode.cn/problems/count-the-number-of-beautiful-subarrays
/// date: 20250306
/// </summary>
public static class Solution2588
{
    public static long BeautifulSubarrays(int[] nums) {
        long result = 0;
        Dictionary<long, long> count = new();
        long xor = 0;
        count[0] = 1;

        foreach (int num in nums) {
            xor ^= num;
            // 如果之前出现过相同的异或和，说明中间这段子数组可以通过操作变成全0
            if (count.ContainsKey(xor)) {
                result += count[xor];
            }
            count[xor] = count.GetValueOrDefault(xor, 0) + 1;
        }

        return result;
    }
}

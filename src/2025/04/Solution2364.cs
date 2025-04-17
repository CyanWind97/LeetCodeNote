using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2364
/// title: 统计坏数对的数目
/// problems: https://leetcode.cn/problems/count-number-of-bad-pairs
/// date: 20250418
/// </summary>
public static class Solution2364
{
    public static long CountBadPairs(int[] nums) {
        int n = nums.Length;
        
        // 坏数对的条件可以重写为：j - i != nums[j] - nums[i]
        // 等价于：nums[j] - j != nums[i] - i
        // 所以我们可以计算每个元素的 nums[i] - i，并找出不相等的对数
        
        Dictionary<int, int> count = new Dictionary<int, int>();
        long goodPairs = 0;
        
        for (int i = 0; i < n; i++) {
            int diff = nums[i] - i;
            
            // 找到与当前元素能形成好数对的数量
            if (count.ContainsKey(diff)) {
                goodPairs += count[diff];
            }
            
            // 更新字典
            if (!count.ContainsKey(diff)) {
                count[diff] = 0;
            }
            count[diff]++;
        }
        
        // 总数对数量 = n * (n - 1) / 2
        long totalPairs = (long)n * (n - 1) / 2;
        
        // 坏数对数量 = 总数对数量 - 好数对数量
        return totalPairs - goodPairs;
    }
}

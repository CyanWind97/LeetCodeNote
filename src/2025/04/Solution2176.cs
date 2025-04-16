using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2176
/// title: 统计数组中相等且可以被整除的数对
/// problems: https://leetcode.cn/problems/count-equal-and-divisible-pairs-in-an-array
/// date: 20250417
/// </summary>
public static class Solution2176
{
    public static int CountPairs(int[] nums, int k) {
        int count = 0;
        int n = nums.Length;
        
        // 创建一个字典，用来存储每个值对应的索引列表
        Dictionary<int, List<int>> valueToIndices = new Dictionary<int, List<int>>();
        
        // 遍历数组，建立值到索引的映射
        for (int i = 0; i < n; i++) {
            if (!valueToIndices.ContainsKey(nums[i])) {
                valueToIndices[nums[i]] = new List<int>();
            }
            valueToIndices[nums[i]].Add(i);
        }
        
        // 遍历字典中每个值对应的索引列表
        foreach (var indices in valueToIndices.Values) {
            // 如果该值只出现一次，跳过
            if (indices.Count < 2) {
                continue;
            }
            
            // 检查所有可能的索引对
            for (int i = 0; i < indices.Count; i++) {
                for (int j = i + 1; j < indices.Count; j++) {
                    // 检查索引对的乘积是否能被k整除
                    if ((indices[i] * indices[j]) % k == 0) {
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
}

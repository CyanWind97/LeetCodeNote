using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 40
/// title: 组合总和 II
/// problems: https://leetcode.cn/problems/combination-sum-ii
/// date: 20250126
/// </summary>
public static class Solution40
{
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        var temp = new List<int>();
        
        // 先排序，便于处理重复元素
        Array.Sort(candidates);
        
        void Backtrack(int start, int remain) {
            if (remain == 0) {
                result.Add(new List<int>(temp));
                return;
            }
            
            for (int i = start; i < candidates.Length; i++) {
                // 剪枝：如果当前数字大于剩余目标值，后面的数字更大，直接结束
                if (candidates[i] > remain) {
                    break;
                }
                
                // 跳过重复数字（确保在同一层不会重复使用相同的数字）
                if (i > start && candidates[i] == candidates[i - 1]) {
                    continue;
                }
                
                temp.Add(candidates[i]);
                // 递归到下一层，注意是i+1因为每个数字只能用一次
                Backtrack(i + 1, remain - candidates[i]);
                temp.RemoveAt(temp.Count - 1);
            }
        }
        
        Backtrack(0, target);
        return result;
    }
}

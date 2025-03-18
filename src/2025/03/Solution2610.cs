using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2610
/// title: 转换二维数组
/// problems: https://leetcode.cn/problems/convert-an-array-into-a-2d-array-with-conditions
/// date: 20250319
/// </summary>
public static class Solution2610
{
    public static IList<IList<int>> FindMatrix(int[] nums) {
        // 使用字典统计每个数字的频率
        Dictionary<int, int> freq = new Dictionary<int, int>();
        IList<IList<int>> result = new List<IList<int>>();
        
        foreach (int num in nums) {
            if (!freq.ContainsKey(num)) {
                freq[num] = 0;
            }
            
            // 如果当前频率等于结果行数，需要创建新行
            if (freq[num] == result.Count) {
                result.Add(new List<int>());
            }
            
            // 将数字添加到对应的行
            result[freq[num]].Add(num);
            // 增加频率
            freq[num]++;
        }
        
        return result;
    }
}

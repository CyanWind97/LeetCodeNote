using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2860
/// title:  让所有学生保持开心的分组方法数
/// problems: https://leetcode.cn/problems/happy-students
/// date: 20240904
/// </summary>
public static class Solution2860
{
    public static int CountWays(IList<int> nums) {
        int n = nums.Count;
        int result = 0;
        var array =  nums.Order().ToArray();

        for(int i = 0; i <= n; i++){
            if (i > 0 && array[i - 1] >= i)
                continue;
            
            if (i < n && array[i] <= i)
                continue;
            
            result++;
        }

        return result;
    }
}

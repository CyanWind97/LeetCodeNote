using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2951
/// title: 找出峰值
/// problems: https://leetcode.cn/problems/find-the-peaks
/// date: 20240528
/// </summary>
public static class Solution2951
{
    public static IList<int> FindPeaks(int[] mountain) {
        int length = mountain.Length;
        List<int> result = new List<int>();
        for(int i = 1; i < length - 1; i++){
            if(mountain[i] > mountain[i - 1] 
            && mountain[i] > mountain[i + 1])
                result.Add(i);
        }

        return result;
    }
}

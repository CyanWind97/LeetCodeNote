using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1287
/// title: 有序数组中出现次数超过25%的元素
/// problems: https://leetcode.cn/problems/element-appearing-more-than-25-in-sorted-array
/// date: 20250217
/// </summary>
public static class Solution1287
{
    public static int FindSpecialInteger(int[] arr) {
        int n = arr.Length;
        int threshold = n / 4;
        
        for (int i = 0; i < n - threshold; i++) {
            if (arr[i] == arr[i + threshold]) {
                return arr[i];
            }
        }
        
        return arr[0]; 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1299
/// title: 将每个元素替换为右侧最大元素
/// problems: https://leetcode.cn/problems/replace-elements-with-greatest-element-on-right-side/
/// date: 20250216
/// </summary>
public static class Solution1299
{
    public static int[] ReplaceElements(int[] arr) {
        int length = arr.Length;
        var rightMax = new int[length];
        var max = -1;

        for(int i = length - 1; i >= 0; i--){
            rightMax[i] = max;
            max = Math.Max(max, arr[i]);
        }

        return rightMax;
    }
}

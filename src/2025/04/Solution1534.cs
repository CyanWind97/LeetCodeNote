using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1534
/// title: 统计好三元组
/// problems: https://leetcode.cn/problems/count-good-triplets
/// date: 20250414
/// </summary>
public static class Solution1534
{
    public static int CountGoodTriplets(int[] arr, int a, int b, int c) {
        int count = 0;
        int n = arr.Length;
        
        // 暴力枚举所有可能的三元组
        for (int i = 0; i < n - 2; i++) {
            for (int j = i + 1; j < n - 1; j++) {
                // 先检查 i 和 j 是否满足第一个条件
                if (Math.Abs(arr[i] - arr[j]) <= a) {
                    for (int k = j + 1; k < n; k++) {
                        // 检查 j 和 k 是否满足第二个条件
                        if (Math.Abs(arr[j] - arr[k]) <= b) {
                            // 检查 i 和 k 是否满足第三个条件
                            if (Math.Abs(arr[i] - arr[k]) <= c) {
                                count++;
                            }
                        }
                    }
                }
            }
        }
        
        return count;
    }
}

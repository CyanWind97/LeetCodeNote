using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3152
/// title: 特殊数组 II
/// problems: https://leetcode.cn/problems/special-array-ii
/// date: 20240814
/// </summary>
public static class Solution3152
{
    public static bool[] IsArraySpecial(int[] nums, int[][] queries) {
        int n = nums.Length;
        var lefts = new List<int>();
        var rights = new List<int>();

        for(int i = 0; i < n - 1; i++){
            if (((nums[i + 1] - nums[i]) & 1) == 0){
                if (rights.Count < lefts.Count)
                    rights.Add(i);
                
            }else if (rights.Count == lefts.Count){
                lefts.Add(i);
            }
        }

        if (rights.Count < lefts.Count)
            rights.Add(n - 1);    

        bool[] result = new bool[queries.Length];

        for(int i = 0; i < result.Length; i++){
            int left = queries[i][0];
            int right = queries[i][1];
            if (left == right){
                result[i] = true;
                continue;
            }

            int index = lefts.BinarySearch(left);
            if  (index < 0)
                index = ~index - 1;

            result[i] = index switch 
            {
                -1 => false,
                _ when index == lefts.Count => false,
                _ when rights[index] >= right => true,
                _ => false
            };
        }

        return result;
    }

    // 参考解答
    // 动态规划
    public static bool[] IsArraySpecial_1(int[] nums, int[][] queries){
        int n = nums.Length;
        var dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = 1; i < n; i++){
            if (((nums[i] - nums[i - 1]) & 1) == 0)
                dp[i] = dp[i - 1] + 1;
        }

        var result = new bool[queries.Length];
        for(int i = 0; i < queries.Length; i++){
            int left = queries[i][0];
            int right = queries[i][1];
            
            result[i] = dp[right] >= right - left + 1;
        }

        return result;
    }
}

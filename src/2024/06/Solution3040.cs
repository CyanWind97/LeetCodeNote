using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3040
/// title: 相同分数的最大操作数目 II
/// problems: https://leetcode.cn/problems/maximum-number-of-operations-with-the-same-score-ii
/// date: 20240608
/// </summary>
public static class Solution3040
{
    public static int MaxOperations(int[] nums) {
        int n = nums.Length;
        var memo = new int[n, n];

        int DFS(int i, int j, int target){
            if (i >= j)
                return 0;
            
            if (memo[i, j] != -1)
                return memo[i, j];
            
            int result = 0;
            if (nums[i] + nums[i + 1] == target)
                result = Math.Max(result,  DFS(i + 2, j, target) + 1);
            
            if (nums[j - 1] + nums[j] == target)
                result = Math.Max(result,  DFS(i, j - 2, target) + 1);
            
            if (nums[i] + nums[j] == target)
                result = Math.Max(result,  DFS(i + 1, j - 1, target) + 1);
            
            memo[i, j] = result;

            return result;
        }

        int Helper(int target){
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;
            
            return DFS(0, n - 1, target);
        }

        int result = 0;
        result = Math.Max(result, Helper(nums[0] + nums[n - 1]));
        result = Math.Max(result, Helper(nums[0] + nums[1]));
        result = Math.Max(result, Helper(nums[n - 2] + nums[n - 1]));

        return result;
    }
}

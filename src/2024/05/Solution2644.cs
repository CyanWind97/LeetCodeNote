using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2644
/// title: 找出可整除性得分最大的整数
/// problems: https://leetcode.cn/problems/find-the-maximum-divisibility-score
/// date: 20240518
/// </summary>

public static class Solution2644
{
    public static int MaxDivScore(int[] nums, int[] divisors) {
        Array.Sort(nums);
        Array.Sort(divisors);
        int n = nums.Length;
        int m = divisors.Length;
        
        int result = int.MaxValue;
        int max = 0;
        int start = 0;
        for(int i = 0; i < m; i++){
            while(start < n && nums[start] < divisors[i])
                start++;

            int count = 0;
            for(int j = start; j < n; j++){
                if(nums[j] % divisors[i] == 0)
                    count++;
            }
            
            if (count > max){
                max = count;
                result = divisors[i];
            } else if(count == max){
                result = Math.Min(result, divisors[i]);
            }
        }

        return result;
    }
}

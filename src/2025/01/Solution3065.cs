using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3065
/// title: 超过阈值的最少操作数 I
/// problems: https://leetcode.cn/problems/minimum-operations-to-exceed-threshold-value-i
/// date: 20250114
/// </summary>
public class Solution3065
{
    public static int MinOperations(int[] nums, int k) {
        Array.Sort(nums);
        var index = Array.BinarySearch(nums, k);
        if(index < 0){
            index = ~index;
        }else{
            while(index >= 0 && nums[index] >= k)
                index--;
            
            index++;
        }
        

        return index;
    }
}

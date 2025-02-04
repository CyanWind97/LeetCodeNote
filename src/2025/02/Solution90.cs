using System;
using System.Collections.Generic;

namespace LeetCodeNote;

/// <summary>
/// no: 90
/// title: 删除排序链表中的重复元素
/// problems: https://leetcode-cn.com/problems/subsets-ii/
/// date: 20250205
/// </summary>
public static partial class Solution90
{
    // 参考解答
    public static IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        int length = nums.Length;
        List<int> tmp = [];
        List<IList<int>> result = [];
        
        for(int mask = 0; mask < ( 1 << length); mask++){
            tmp.Clear();
            bool flag = true;
            for(int i = 0; i < length; i++){
                if((mask & (1 << i)) != 0){
                    if(i > 0 && (mask >> (i - 1) & 1) == 0 && nums[i] == nums[i - 1]) {
                        flag = false;
                        break;
                    }
                    tmp.Add(nums[i]);
                }
            }
            if(flag){
                result.Add([.. tmp]);
            }
        }
        
        return result;
    }   
}
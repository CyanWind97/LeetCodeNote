using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2974
/// title:  最小数字游戏
/// problems: https://leetcode.cn/problems/minimum-number-game
/// date: 20240712
/// </summary>
public static class Solution2974
{
    public static int[] NumberGame(int[] nums) {
        Array.Sort(nums);
        
        for(int i = 0; i < nums.Length; i+=2){
            (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
        }

        return nums;
    }
}

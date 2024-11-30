using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3232
/// title: 判断是否可以赢得数字游戏
/// problems: https://leetcode.cn/problems/find-if-digit-game-can-be-won
/// date: 20241130
/// </summary>
public static class Solution3232
{
    public static bool CanAliceWin(int[] nums) {
        var total = 0;
        var alice = 0;
        foreach(var num in nums){
            total += num;
            if (num < 10)
                alice += num;
        }

        return 2 * alice != total;
    }
}

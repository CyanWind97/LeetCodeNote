using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3158
/// title: 求出出现两次数字的 XOR 值
/// problems: https://leetcode.cn/problems/find-the-xor-of-numbers-which-appear-twice
/// date: 20241011
/// </summary>
public static class Solution3158
{
    public static int DuplicateNumbersXOR(int[] nums) {
        var set = new HashSet<int>();
        int xor = 0;
        foreach(var num in nums){
            if(!set.Add(num))
                xor ^= num;
        }

        return xor;
    }
}

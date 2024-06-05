using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2938
/// title: 区分黑球与白球
/// problems: https://leetcode.cn/problems/separate-black-and-white-balls/description/?envType=daily-question&envId=2024-06-06
/// date: 20240606
/// </summary>
public static class Solution2938
{
    public static long MinimumSteps(string s) {
        var result = 0L;
        int sum = 0;

        foreach(var c in s){
            if (c == '1'){
                sum++;
            }else{
                result += sum;
            }
        }

        return result;
    }
}

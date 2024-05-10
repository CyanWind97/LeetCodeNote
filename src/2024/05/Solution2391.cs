using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2391
/// title: 收集垃圾的最少总时间
/// problems: https://leetcode.cn/problems/minimum-amount-of-time-to-collect-garbage
/// date: 20240511
/// </summary>
public static class Solution2391
{
    public static int GarbageCollection(string[] garbage, int[] travel) {
        int length = garbage.Length;
        int sum = travel.Sum();
        int result = 3 * sum + garbage.Sum(x => x.Length);

        void CalcNotArrived(char c) {
            for(int i = 1; i < length; i++) {
                if(garbage[^i].Contains(c))
                    break;
                
                result -= travel[^i];
            }
        }

        CalcNotArrived('M');
        CalcNotArrived('P');
        CalcNotArrived('G');

        return result;
    }
}

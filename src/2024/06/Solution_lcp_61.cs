using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 61
/// title: 气温变化趋势
/// problems: https://leetcode.cn/problems/6CE719
/// date: 20240621
/// type: lcp
/// </summary>
public class Solution_lcp_61
{
    public static int TemperatureTrend(int[] temperatureA, int[] temperatureB) {
        int n = temperatureA.Length;
        int result = 0;
        int curr = 0;
        for(int i = 1; i < n; i++){
            int a = temperatureA[i].CompareTo(temperatureA[i - 1]);
            int b = temperatureB[i].CompareTo(temperatureB[i - 1]);
            if (a == b){
                curr++;
            }else{
                result = Math.Max(result, curr);
                curr = 0;
            }
        }
    
        return Math.Max(result, curr);
    }
}

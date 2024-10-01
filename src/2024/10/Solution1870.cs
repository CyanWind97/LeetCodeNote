using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1870
/// title: 准时到达的列车最小时速
/// problems: https://leetcode.cn/problems/minimum-speed-to-arrive-on-time
/// date: 20241002
/// </summary>
public static class Solution1870
{
    public static int MinSpeedOnTime(int[] dist, double hour) {
        int n = dist.Length;
        if(hour <= n - 1)
            return -1;

        int Calc(int speed){
            double time = 0;
            for(int i = 0; i < n - 1; i++){
                time += Math.Ceiling((double)dist[i] / speed);
            }

            time += (double)dist[n - 1] / speed;

            return time <= hour ? speed : -1;
        }

        int left = 1;
        int right = 10000000;
        while(left < right){
            int mid = left + (right - left) / 2;
            if(Calc(mid) == -1)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}

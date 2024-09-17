using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2332
/// title: 坐上公交的最晚时间
/// problems: https://leetcode.cn/problems/the-latest-time-to-catch-a-bus
/// date: 20240918
/// </summary>
public static class Solution2332
{
    public static int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity) {
        Array.Sort(buses);
        Array.Sort(passengers);

        int index = 0;
        int space = 0;
        foreach(var arrive in buses){
            space = capacity;
            while(space > 0 
            && index < passengers.Length 
            && passengers[index] <= arrive){
                space--;
                index++;
            }
        }

        index--;
        int lastTime = space > 0 
                    ? buses[^1]
                    : passengers[index]; 

        while(index >= 0 && passengers[index] == lastTime){
            index--;
            lastTime--;
        }

        return lastTime;
    }
}

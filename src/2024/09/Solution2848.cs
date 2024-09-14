using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2848
/// title: 与车相交的点
/// problems: https://leetcode.cn/problems/points-that-intersect-with-cars
/// date: 20240915
/// </summary>
public static class Solution2848
{
    public static int NumberOfPoints(IList<IList<int>> nums) {
        int max = nums.Max(x => x[1]);
        var diff = new int[max + 2];

        foreach(var car in nums){
            diff[car[0]]++;
            diff[car[1] + 1]--;
        }

        int result = 0;
        int count = 0;

        for(int i = 1; i <= max; i++){
            count += diff[i];
            if(count > 0)
                result++;
        }

        return result;
    }
}

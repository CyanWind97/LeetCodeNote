using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2748
/// title: 美丽下标对的数目
/// problems: https://leetcode.cn/problems/number-of-beautiful-pairs
/// date: 20240620
/// </summary>
public static class Solution2748
{
    public static int CountBeautifulPairs(int[] nums) {
        int GCD(int a, int b) 
            => b == 0 ? a : GCD(b, a % b);

        int result = 0;
        var count = new int[10];

        foreach(var x in nums){
            for(int y = 1; y <= 9; y++){
                if (GCD(x % 10, y) == 1)
                    result += count[y];
            }

            int z = x;
            while(z >= 10){
                z /= 10;
            }

            count[z]++;
        }

        return result;
    }
}

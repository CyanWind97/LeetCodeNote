using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2961
/// title: 双模幂运算
/// problems: https://leetcode.cn/problems/double-modular-exponentiation
/// date: 20240730
/// </summary>
public static class Solution2961
{
    public static IList<int> GetGoodIndices(int[][] v, int target) {
        int CalcPower(int x, int y, int mod){
            int result = 1;
            x %= mod;
            while(y > 0){
                if(y % 2 == 1)
                    result = (result * x) % mod;
                
                x = (x * x) % mod;
                y /= 2;
            }

            return result;
        }

        return Enumerable.Range(0, v.Length)
            .Where(i => CalcPower(CalcPower(v[i][0], v[i][1], 10), v[i][2], v[i][3]) == target)
            .ToList();
    }
}

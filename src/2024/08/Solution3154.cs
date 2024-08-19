using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3154
/// title: 到达第 K 级台阶的方案数
/// problems: https://leetcode.cn/problems/find-number-of-ways-to-reach-the-k-th-stair
/// date: 20240820
/// </summary>
public static class Solution3154
{

    // 参考解答
    // 组合数学
    public static int WaysToReachStair(int k) {
        int n = 0, npow = 1, result = 0;
       
        int Comb(int n, int k){
            long result = 1;
            for(int i = 1; i <= k; i++){
                result = result * (n - i + 1) / i;
            }
            
            return (int)result;
        }

        while(npow - n - 1 <= k){
            if (k <= npow)
                result += Comb(n + 1, npow - k);

            n++;
            npow *= 2; 
        }

        return result;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1387
/// title: 将整数按权重排序
/// problems: https://leetcode.cn/problems/sort-integers-by-the-power-value
/// date: 20241222
/// </summary>
public static class Solution1387
{
    public static int GetKth(int lo, int hi, int k) {
        static int CalcWeight(int num){
            if (num == 1)
                return 0;
        
            int x = num;
            int count = 0;
            while(x != 1){
                if ((x & 1) == 0){
                    x >>= 1;
                    count++;
                }else{
                    x += ((x + 1) >> 1);
                    count+=2;
                }
            }

            return count;
        }

        return Enumerable.Range(lo, hi - lo + 1)
            .OrderBy(x => CalcWeight(x))
            .ElementAt(k - 1);
    }
}

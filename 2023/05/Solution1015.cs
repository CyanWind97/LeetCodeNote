using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1015
    /// title: 可被 K 整除的最小整数
    /// problems: https://leetcode.cn/problems/smallest-integer-divisible-by-k/
    /// date: 20230510
    /// </summary>
    public static class Solution1015
    {
        public static int SmallestRepunitDivByK(int k) {
            if(k % 2 == 0 || k % 5 == 0)
                return -1;
            
            int remainder = 0;
            for(int i = 1; i <= k; i++){
                remainder = (remainder * 10 + 1) % k;
                if(remainder == 0)
                    return i;
            }

            return -1;
        }
    }
}
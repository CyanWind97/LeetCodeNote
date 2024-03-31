using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2427
    /// title: 公因子的数目
    /// problems: https://leetcode.cn/problems/number-of-common-factors/
    /// date: 20230405
    /// </summary>
    public static class Solution2427
    {
        public static int CommonFactors(int a, int b) {
            while(b != 0){
                a %= b;
                (a, b) = (b, a);
            }

            int count = 0;
            for(int i = 1; i  * i <= a; i++){
                if(a % i == 0){
                    count++;
                    if(i * i != a)
                        count++;
                }
            }

            return count;
        }
    }
}
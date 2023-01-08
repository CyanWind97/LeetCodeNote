using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1806
    /// title: 还原排列的最少操作步数
    /// problems: https://leetcode.cn/problems/minimum-number-of-operations-to-reinitialize-a-permutation/
    /// date: 20230109
    /// </summary>
    public class Solution1806
    {   
        // 参考解答 数学
        public static int ReinitializePermutation(int n) {
            if (n == 2)
                return 1;
            
            int step = 1;
            int pow2 = 2;
            while(pow2 != 1){
                step++;
                pow2 = pow2 * 2 % (n - 1);
            }

            return step;
        }
    }
}
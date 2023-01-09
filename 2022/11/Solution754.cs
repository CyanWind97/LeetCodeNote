using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 754
    /// title: 到达终点数字
    /// problems: https://leetcode.cn/problems/reach-a-number/
    /// date: 20221104
    /// </summary>    
    public static class Solution754
    {
        // 参考解答
        // 分段 + 数学
        public static int ReachNumber(int target) {
            target = Math.Abs(target);
            int k = 0;

            while(target > 0){
                k++;
                target -= k;
            }

            return target % 2 == 0 ? k : k + 1 + k % 2;
        }
    }
}
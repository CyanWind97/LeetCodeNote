using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1780
    /// title:  判断一个数字是否可以表示成三的幂的和
    /// problems: https://leetcode.cn/problems/check-if-number-is-a-sum-of-powers-of-three/
    /// date: 20221209
    /// </summary>
    public static class Solution1780
    {
        // 参考解答
        // 转化为3进制
        public static bool CheckPowersOfThree(int n) {
            while(n > 0){
                if(n % 3 == 2)
                    return false;
                
                n /= 3;
            }

            return true;
        }
    }
}
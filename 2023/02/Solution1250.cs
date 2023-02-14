using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1250
    /// title: 检查「好数组」
    /// problems: https://leetcode.cn/problems/check-if-it-is-a-good-array/
    /// date: 20230215
    /// </summary>
    public static class Solution1250
    {
        public static bool IsGoodArray(int[] nums) {
            int GCD(int m, int n){
                while(n != 0){
                    (m, n) = (n, m % n);
                }

                return m;
            }

            int divisor = nums[0];
            foreach(var num in nums){
                divisor = GCD(divisor, num);
                if(divisor == 1)
                    break;
            }

            return divisor == 1;
        }
    }
}
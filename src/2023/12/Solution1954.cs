using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1954
    /// title: 收集足够苹果的最小花园周长
    /// problems: https://leetcode.cn/problems/minimum-garden-perimeter-to-collect-enough-apples/description/?envType=daily-question&envId=2023-12-24
    /// date: 20231224
    /// </summary>
    public static class Solution1954
    {
        public static long MinimumPerimeter(long neededApples) {
            (long left, long right) = (1, 100000);
            long result = 0;

            while(left <= right){
                long mid = left + (right - left) / 2;
                long sum = 2 * mid * (mid + 1) * (2 * mid + 1);
                if(sum >= neededApples){
                    result = mid;
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }

            return result * 8;
        }
    }
}
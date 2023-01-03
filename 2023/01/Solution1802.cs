using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1802
    /// title: 有界数组中指定下标处的最大值
    /// problems: https://leetcode.cn/problems/maximum-value-at-a-given-index-in-a-bounded-array/
    /// date: 20230103
    /// </summary>
    public static class Solution1802
    {
        // 参考解答
        // 贪心 + 二分查找
        public static int MaxValue(int n, int index, int maxSum) {
            bool Valid(int mid){
                int left = index;
                int right = n - index - 1;
                return mid + Cal(mid, left) + Cal(mid, right) <= maxSum;
            }

            long Cal(int big, int length){
                if(length + 1 < big){
                    int small = big - length;
                    return (long)(big - 1 + small) * length / 2;
                }else{
                    int ones = length - (big - 1);
                    return (long)big * (big - 1) / 2 + ones;
                }
            }

            int left = 1;
            int right = maxSum;
            while(left < right){
                int mid = (left + right + 1) / 2;
                if (Valid(mid))
                    left = mid;
                else 
                    right = mid - 1;
            }   

            return left;
        }
    }
}
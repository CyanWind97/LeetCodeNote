using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1760
    /// title: 袋子里最少数目的球
    /// problems: https://leetcode.cn/problems/minimum-limit-of-balls-in-a-bag/
    /// date: 20221220
    /// </summary>
    public static class Solution1760
    {   
        // 参考解答
        // 二分查找
        public static int MinimumSize(int[] nums, int maxOperations) {
            int left = 1;
            int right = nums.Max();
            int result = 0;
            while(left <= right){
                int mid = (left + right) / 2;
                long ops = 0;
                foreach(var num in nums){
                    ops += (num - 1) / mid;
                }

                if(ops <= maxOperations){
                    result = mid;
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
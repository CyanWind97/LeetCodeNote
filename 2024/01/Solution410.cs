using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 410
    /// title: 分割数组的最大值
    /// problems: https://leetcode.cn/problems/split-array-largest-sum/description/?envType=daily-question&envId=2024-01-21
    /// date: 20240121
    /// </summary>
    public static class Solution410
    {
        public static int SplitArray(int[] nums, int k) {
            int left = nums.Max();
            int right = nums.Sum();

            bool check(int limitSum){
                int count = 1;
                int sum = 0;
                foreach(var num in nums){
                    if(sum + num > limitSum){
                        count++;
                        sum = num;
                    }else{
                        sum += num;
                    }
                }

                return count <= k;
            }

            while(left < right){
                int mid = left + (right - left) / 2;
                if(check(mid))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2367
    /// title: 算术三元组的数目
    /// problems: https://leetcode.cn/problems/number-of-arithmetic-triplets/
    /// date: 20230331
    /// </summary>
    public static class Solution2367
    {
        public static int ArithmeticTriplets(int[] nums, int diff) {
            int result = 0;
            int n = nums.Length;
            for(int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++){
                j = Math.Max(j, i + 1);
                while(j < n - 1 && nums[j] - nums[i] < diff){
                    j++;
                }

                if(j >= n - 1 || nums[j] - nums[i] > diff)
                    continue;
                
                k = Math.Max(k, j + 1);
                while(k < n && nums[k] - nums[j] < diff){
                    k++;
                }

                if(k < n && nums[k] - nums[j] == diff)
                    result++;
            }

            return result;
        }
    }
}
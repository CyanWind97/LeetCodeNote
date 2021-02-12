using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 448
    /// title: 找到所有数组中消失的数字
    /// problems: https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/
    /// date: 20210213
    /// </summary>
    public static class Solution448
    {
        public static IList<int> FindDisappearedNumbers(int[] nums) {
            List<int> result = new List<int>();
            int n = nums.Length;
            Array.Sort(nums);
            int i = 0;
            int j = 1;
            while(i < n || j <= n){
                if(i == n || nums[i] > j){
                    result.Add(j++);
                }else if(nums[i] < j){
                    i++;
                }else{
                    i++;
                    j++;
                }
            }

            return result;
        }

        // 参考解答
        public static IList<int> FindDisappearedNumbers_1(int[] nums) {
            List<int> result = new List<int>();
            int n = nums.Length;
            foreach(var num in nums){
                int index = Math.Abs(num) - 1;
                if(nums[index] > 0) 
                    nums[index] *= -1;
            }
            for(int i = 0; i < n; i++){
                if(nums[i] > 0)
                    result.Add(i + 1);
            }

            return result;
        }
    }
}
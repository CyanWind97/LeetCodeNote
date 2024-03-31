using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 740
    /// title:  删除并获得点数
    /// problems: https://leetcode-cn.com/problems/delete-and-earn/
    /// date: 20210505
    /// </summary>
    public static class Solution740
    {
        public static int DeleteAndEarn(int[] nums) {
            Array.Sort(nums);
            int length = nums.Length;
            int result = 0;

            List<int> sum = new List<int>();
            sum.Add(nums[0]);
            int size = 1;

            int Rob(){
                if(size == 1)
                    return sum[0];
                
                int first = sum[0];
                int second = Math.Max(sum[0], sum[1]);
                for(int i = 2; i < size; i++){
                    (first, second) = (second, Math.Max(first + sum[i], second));
                }

                return second;
            }

            for(int i = 1; i < length; i++){
                int val = nums[i];
                if(val == nums[i - 1]){
                    sum[size - 1] += val;
                }else if(val == nums[i - 1] + 1){
                    sum.Add(val);
                    size++;
                }else{
                    result += Rob();
                    sum.Clear();
                    sum.Add(val);
                    size = 1;
                }
            }

            result += Rob();
            return result;

        }
    }
}
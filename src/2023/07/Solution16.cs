using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 16
    /// title:  最接近的三数之和
    /// problems: https://leetcode.cn/problems/3sum-closest/
    /// date: 20230710
    /// </summary>
    public static class Solution16
    {
        public static int ThreeSumClosest(int[] nums, int target) {
            Array.Sort(nums);
            int length = nums.Length;
            int result = nums[0] + nums[1] + nums[2];
            for(int i = 0; i < length - 2; i++){
                int left = i + 1;
                int right = length - 1;
                while(left < right){
                    int sum = nums[i] + nums[left] + nums[right];
                    if(sum == target)
                        return sum;
                    else if(sum < target)
                        left++;
                    else
                        right--;
                    
                    if(Math.Abs(sum - target) < Math.Abs(result - target))
                        result = sum;
                }
            }

            return result;
        }
    }
}
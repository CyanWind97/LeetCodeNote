using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 628
    /// title: 三个数的最大乘积
    /// problems: https://leetcode-cn.com/problems/maximum-product-of-three-numbers/
    /// date: 20210120
    /// </summary>
    public static class Solution628
    {
        public static int MaximumProduct(int[] nums) {
            int min1 = int.MaxValue, min2 = int.MaxValue;
            int max1 = int.MinValue, max2 = int.MaxValue, max3 = int.MaxValue;
            foreach(var x in nums){
                if(x > max1){
                    max3 = max2;
                    max2 = max1;
                    max1 = x;
                }else if(x > max2){
                    max3 = max2;
                    max2 = x;
                }else if(x > max3){
                    max3 = x;
                }

                if(x < min1){
                    min2 = min1;
                    min1 = x;
                }else if(x < min2){
                    min2 = x;
                }
            }

            return max1 * (max1 > 0 ? Math.Max(min1 * min2, max2 * max3) : Math.Min(min1 * min2, max2 * max3));
        }

        // Sort
        public static int MaximumProduct_1(int[] nums) {
            int length = nums.Length;
            if(length == 3)
                return  nums[0] * nums[1] * nums[2];         
            
            Array.Sort(nums);

            return nums[length - 1] > 0
                ? nums[length - 1] * Math.Max(nums[0] * nums[1], nums[length - 2] * nums[length - 3])
                : nums[length - 1] * nums[length - 2] * nums[length - 3];
        }
    }
}
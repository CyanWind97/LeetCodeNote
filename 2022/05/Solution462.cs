using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 462
    /// title: 最少移动次数使数组元素相等 II
    /// problems: https://leetcode.cn/problems/minimum-moves-to-equal-array-elements-ii/
    /// date: 20220519
    /// </summary>  
    public static class Solution462
    {
        public static int MinMoves2(int[] nums) {
            Array.Sort(nums);

            int length = nums.Length;
            int result = 0;

            for(int i = 0; i < length / 2; i++){
                result +=  nums[length - i - 1] - nums[i];
            }

            return result;
        }

        public static int MinMoves2_1(int[] nums){
            var random = new Random();

            int QuickSelect(int left, int right, int index) {
                int q = RandomPartition(nums, left, right);
                if (q == index) 
                    return nums[q];
                else
                    return q < index 
                        ? QuickSelect(q + 1, right, index) 
                        : QuickSelect(left, q - 1, index);
            }

            int RandomPartition(int[] nums, int left, int right) {
                int i = random.Next(right - left + 1) + left;
                (nums[i], nums[right]) = (nums[right], nums[i]);

                return Partition(nums, left, right);
            }

            int Partition(int[] nums, int left, int right) {
                int x = nums[right], i = left - 1;
                for (int j = left; j < right; ++j) {
                    if (nums[j] <= x) {
                        ++i;
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                    }
                }

                (nums[i + 1], nums[right]) = (nums[right], nums[i + 1]);

                return i + 1;
            }

            int length = nums.Length;
            int x = QuickSelect(0, length - 1, length / 2);
            
            return nums.Sum(num => Math.Abs(num - x));
        }
    }
}
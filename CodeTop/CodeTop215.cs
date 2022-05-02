using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 215
    /// title:  数组中的第K个最大元素
    /// problems: https://leetcode-cn.com/problems/kth-largest-element-in-an-array/
    /// date: 20220502
    /// priority: 0001
    /// time: 00:01:49.49 (非快排)
    /// </summary>
    public static class CodeTop215
    {
        public static int FindKthLargest(int[] nums, int k) 
        {
            Array.Sort(nums);
            int length = nums.Length;

            return nums[length - k];
        }


        // 参考思路 优化 快排 分治
        // 主要目的是考察快排和堆排
        public static int FindKthLargest_1(int[] nums, int k)
        {
            var random = new Random();

            int QuickSelect(int left, int right){
                int q = RanomPartition(left, right);
                if(q == k - 1)
                    return nums[q];
                else
                    return q < k - 1 
                        ? QuickSelect(q + 1, right) 
                        : QuickSelect(left, q - 1);
            }

            int RanomPartition(int left, int right){
                int index = random.Next(right - left + 1) + left;
                (nums[index], nums[right]) = (nums[right], nums[index]);

                return Partition(left, right);
            }

            int Partition(int left, int right){
                int num = nums[right];
                int index = left - 1;
                for(int j = left; j < right; j++){
                    if(nums[j] >= num){
                        index++;
                        (nums[index], nums[j]) = (nums[j], nums[index]);
                    }
                }
                
                (nums[index + 1], nums[right]) = (nums[right], nums[index + 1]);

                return index + 1;
            }

            return QuickSelect(0, nums.Length - 1);
        }
    }
}
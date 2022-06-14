using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 719
    /// title: 找出第 K 小的数对距离
    /// problems: https://leetcode.cn/problems/find-k-th-smallest-pair-distance/
    /// date: 20220615
    /// </summary>
    public static class Solution719
    {
        // 参考解答 排序 + 二分查找 + 双指针
        public static int SmallestDistancePair(int[] nums, int k) {
            Array.Sort(nums);
            int length = nums.Length;
            int left = 0, right = nums[length - 1] - nums[0];

            while(left <= right){
                int mid = (left + right) / 2;
                int count = 0;
                for(int i = 0, j = 0; j < length; j++){
                    while(nums[j] - nums[i] > mid){
                        i++;
                    }

                    count += j - i;
                }
                if(count >= k)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return left;
        }     
    }
}
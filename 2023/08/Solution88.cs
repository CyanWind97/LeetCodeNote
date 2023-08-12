using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 88
    /// title: 合并两个有序数组
    /// problems: https://leetcode.cn/problems/merge-sorted-array/
    /// date: 20230813
    /// </summary>
    public static class Solution88
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int index = m + n - 1;
            int i = m - 1;
            int j = n - 1;
            while(i >= 0 || j >= 0){
                nums1[index--] = i == -1 || (j >= 0 && nums2[j] > nums1[i])
                            ? nums2[j--] 
                            : nums1[i--];
            }
        }
    }
}
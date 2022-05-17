using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 88
    /// title:  合并两个有序数组
    /// problems: https://leetcode.cn/problems/merge-sorted-array/
    /// date: 20220512
    /// priority: 0072
    /// time: 00:06:58.06
    public static class CodeTop44
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int index = m + n - 1;
            int i = m - 1;
            int j = n - 1;
            while(i >= 0 || j >= 0){
                if(i == -1 || (j >= 0 && nums2[j] > nums1[i]))
                    nums1[index--] = nums2[j--];
                else
                    nums1[index--] = nums1[i--];
            }
        }
    }
}
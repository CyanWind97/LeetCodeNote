using System;
using System.Linq;

namespace LeetCodeNote
{   
    /// <summary>
    /// no: 870
    /// title: 优势洗牌
    /// problems: https://leetcode.cn/problems/advantage-shuffle/
    /// date: 20221008
    /// </summary>
    public static class Solution870
    {
        public static int[] AdvantageCount(int[] nums1, int[] nums2) {
            int n = nums1.Length;
            int[] idx1 = Enumerable.Range(0, n).ToArray();
            int[] idx2 = Enumerable.Range(0, n).ToArray();

            Array.Sort(idx1, (i, j) => nums1[i] - nums1[j]);
            Array.Sort(idx2, (i, j) => nums2[i] - nums2[j]);

            int[] result = new int[n];
            int left = 0, right = n - 1;
            for (int i = 0; i < n; ++i) {
                if (nums1[idx1[i]] > nums2[idx2[left]]) {
                    result[idx2[left]] = nums1[idx1[i]];
                    ++left;
                } else {
                    result[idx2[right]] = nums1[idx1[i]];
                    --right;
                }
            }
            
            return result;
        }
    }
}
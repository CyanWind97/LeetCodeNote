using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 88
    /// title: 合并两个有序数组
    /// problems: https://leetcode-cn.com/problems/merge-sorted-array/
    /// date: 20210405
    /// </summary>
    public static partial class Solution88
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int[] tmp = nums1.Take(m).ToArray();
            
            int i = 0, j = 0, k = 0;
            while(k < m + n)
            {
                if(i == m || (j < n && tmp[i] > nums2[j]))
                    nums1[k++] = nums2[j++];
                else
                    nums1[k++] = tmp[i++];
            }
        }

        // 参考解答 nums1 足够大， 优先取最大
        public static void Merge_1(int[] nums1, int m, int[] nums2, int n) {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while(k >= 0)
            {
                if(i == -1 || (j >= 0 && nums1[i] < nums2[j]))
                    nums1[k--] = nums2[j--];
                else
                    nums1[k--] = nums1[i--];
            }
        }
    }
}
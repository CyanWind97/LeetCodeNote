using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 373
    /// title: 查找和最小的 K 对数字
    /// problems: https://leetcode-cn.com/problems/find-k-pairs-with-smallest-sums/
    /// date: 20220114
    /// </summary>
    public static class Solution373
    {
        // 参考解答 二分查找
        public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
            int m = nums1.Length;
            int n = nums2.Length;

            /*二分查找第 k 小的数对和的大小*/
            int left = nums1[0] + nums2[0];
            int right = nums1[m - 1] + nums2[n - 1];
            int pairSum = right;
            while (left <= right) {
                int mid = left + ((right - left) >> 1);
                long cnt = 0;
                int start = 0;
                int end = n - 1;
                while (start < nums1.Length && end >= 0) {
                    if (nums1[start] + nums2[end] > mid) {
                        end--;
                    } else {
                        cnt += end + 1;
                        start++;
                    }
                }
                if (cnt < k) {
                    left = mid + 1;
                } else {
                    pairSum = mid;
                    right = mid - 1;
                }
            }

            IList<IList<int>> ans = new List<IList<int>>();
            int pos = n - 1;
            /*找到小于目标值 pairSum 的数对*/
            for (int i = 0; i < m; i++) {
                while (pos >= 0 && nums1[i] + nums2[pos] >= pairSum) {
                    pos--;
                }
                for (int j = 0; j <= pos && k > 0; j++, k--) {
                    IList<int> list = new List<int>();
                    list.Add(nums1[i]);
                    list.Add(nums2[j]);
                    ans.Add(list);
                }
            }

            /*找到等于目标值 pairSum 的数对*/
            pos = n - 1;
            for (int i = 0; i < m && k > 0; i++) {
                while (pos >= 0 && nums1[i] + nums2[pos] > pairSum) {
                    pos--;
                }
                for (int j = i; k > 0 && j >= 0 && nums1[j] + nums2[pos] == pairSum; j--, k--) {
                    IList<int> list = new List<int>();
                    list.Add(nums1[j]);
                    list.Add(nums2[pos]);
                    ans.Add(list);
                }
            }
            return ans;
        }
    }
}
using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1818
    /// title: 绝对差值和
    /// problems: https://leetcode-cn.com/problems/minimum-absolute-sum-difference/
    /// date: 20210714
    /// </summary>
    public static class Solution1818
    {
        // 参考解答 排序 + 二分查找
        public static int MinAbsoluteSumDiff(int[] nums1, int[] nums2) {
            const int MOD = 1000000007;
            int n = nums1.Length;
            int[] rec = new int[n];
            Array.Copy(nums1, rec, n);
            Array.Sort(rec);

            int BinarySearch(int target) {
                int low = 0, high = rec.Length - 1;
                if (rec[high] < target) {
                    return high + 1;
                }
                while (low < high) {
                    int mid = (high - low) / 2 + low;
                    if (rec[mid] < target) {
                        low = mid + 1;
                    } else {
                        high = mid;
                    }
                }
                return low;
            }

            int sum = 0, maxn = 0;
            for (int i = 0; i < n; i++) {
                int diff = Math.Abs(nums1[i] - nums2[i]);
                sum = (sum + diff) % MOD;
                int j = BinarySearch(nums2[i]);
                if (j < n) {
                    maxn = Math.Max(maxn, diff - (rec[j] - nums2[i]));
                }
                if (j > 0) {
                    maxn = Math.Max(maxn, diff - (nums2[i] - rec[j - 1]));
                }
            }
            return (sum - maxn + MOD) % MOD;
        }
    }
}
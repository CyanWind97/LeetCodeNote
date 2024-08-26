using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3134
/// title: 找出唯一性数组的中位数
/// problems: https://leetcode.cn/problems/find-the-median-of-the-uniqueness-array
/// date: 20240827
/// </summary>
public static class Solution3134
{
    // 参考解答
    // 二分查找
    public static int MedianOfUniquenessArray(int[] nums) {
        int n = nums.Length;
        long median = ((long) n * (n + 1) / 2 + 1) / 2;
        int res = 0;
        int lo = 1, hi = n;
        bool Check(int[] nums, int t, long median) {
            var cnt = new Dictionary<int, int>();
            long tot = 0;
            for (int i = 0, j = 0; i < nums.Length; i++) {
                if (cnt.ContainsKey(nums[i])) {
                    cnt[nums[i]]++;
                } else {
                    cnt[nums[i]] = 1;
                }
                while (cnt.Count > t) {
                    cnt[nums[j]]--;
                    if (cnt[nums[j]] == 0) {
                        cnt.Remove(nums[j]);
                    }
                    j++;
                }
                tot += i - j + 1;
            }
            return tot >= median;
        }

        while (lo <= hi) {
            int mid = (lo + hi) / 2;
            if (Check(nums, mid, median)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
}

using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1723
    /// title: 完成所有工作的最短时间
    /// problems: https://leetcode-cn.com/problems/find-minimum-time-to-finish-all-jobs/
    /// date: 20210506
    /// </summary>
    public static class Solution1723
    {
        // 参考解答 二分
        public static int MinimumTimeRequired(int[] jobs, int k) {
            Array.Sort(jobs);
            Array.Reverse(jobs);
            int l = jobs[0], r = jobs.Sum();

            bool Backtrack(int[] workloads, int i, int limit) {
                if (i >= jobs.Length) {
                    return true;
                }
                int cur = jobs[i];
                for (int j = 0; j < workloads.Length; ++j) {
                    if (workloads[j] + cur <= limit) {
                        workloads[j] += cur;
                        if (Backtrack(workloads, i + 1, limit)) {
                            return true;
                        }
                        workloads[j] -= cur;
                    }
                    // 如果当前工人未被分配工作，那么下一个工人也必然未被分配工作
                    // 或者当前工作恰能使该工人的工作量达到了上限
                    // 这两种情况下我们无需尝试继续分配工作
                    if (workloads[j] == 0 || workloads[j] + cur == limit) {
                        break;
                    }
                }
                return false;
            }

            bool Check(int limit) {
                int[] workloads = new int[k];
                return Backtrack(workloads, 0, limit);
            }


            while (l < r) {
                int mid = (l + r) >> 1;
                if (Check(mid)) {
                    r = mid;
                } else {
                    l = mid + 1;
                }
            }
            
            return l;
        }
    }
}
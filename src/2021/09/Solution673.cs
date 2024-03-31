using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 673
    /// title: 最长递增子序列的个数
    /// problems: https://leetcode-cn.com/problems/number-of-longest-increasing-subsequence/
    /// date: 20210920
    /// </summary>
    public static class Solution673
    {
        // 参考解答 贪心 + 前缀和 + 二分查找
        public static int FindNumberOfLIS(int[] nums) {
            IList<IList<int>> d = new List<IList<int>>();
            IList<IList<int>> cnt = new List<IList<int>>();
            int BinarySearch1(int n, IList<IList<int>> d, int target) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (d[mid].Last() >= target) 
                        r = mid;
                    else 
                        l = mid + 1;
                    
                }
                return l;
            }

            int BinarySearch2(int n, IList<int> list, int target) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (list[mid] < target)
                        r = mid;
                    else
                        l = mid + 1;
                }
                return l;
            }

            foreach (int v in nums) {
                int i = BinarySearch1(d.Count, d, v);
                int c = 1;
                if (i > 0) {
                    int k = BinarySearch2(d[i - 1].Count, d[i - 1], v);
                    c = cnt[i - 1][cnt[i - 1].Count - 1] - cnt[i - 1][k];
                }
                if (i == d.Count) {
                    IList<int> dIList = new List<int>();
                    dIList.Add(v);
                    d.Add(dIList);
                    IList<int> cntIList = new List<int>();
                    cntIList.Add(0);
                    cntIList.Add(c);
                    cnt.Add(cntIList);
                } else {
                    d[i].Add(v);
                    int cntSize = cnt[i].Count;
                    cnt[i].Add(cnt[i][cntSize - 1] + c);
                }
            }

            int count1 = cnt.Count, count2 = cnt[count1 - 1].Count;
            return cnt[count1 - 1][count2 - 1];
        }

    }
}
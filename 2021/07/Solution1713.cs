using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1713
    /// title: 大餐计数
    /// problems: https://leetcode-cn.com/problems/minimum-operations-to-make-a-subsequence/
    /// date: 20210726
    /// </summary>
    public static class Solution1713
    {
        // dp超时
        // 参考解答 贪心 + 二分查找
        public static int MinOperations(int[] target, int[] arr) {
            int length = target.Length;
            Dictionary<int, int> pos = new Dictionary<int, int>();
            for (int i = 0; i < length; ++i) {
                pos.Add(target[i], i);
            }
            IList<int> d = new List<int>();

            int BinarySearch(int x) {
                int size = d.Count;
                if (size == 0 || d[size - 1] < x)
                    return size;
                
                int low = 0, high = size - 1;
                while (low < high) {
                    int mid = (high - low) / 2 + low;
                    if (d[mid] < x)
                        low = mid + 1;
                    else
                        high = mid;
                }
                return low;
            }

            foreach (int val in arr) {
                if (pos.ContainsKey(val)) {
                    int idx = pos[val];
                    int it = BinarySearch(idx);
                    if (it != d.Count) 
                        d[it] = idx;
                    else
                        d.Add(idx);
                }
            }
            
            return length - d.Count;
        }
    }
}
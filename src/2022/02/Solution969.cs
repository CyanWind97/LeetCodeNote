using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 969
    /// title: 煎饼排序
    /// problems: https://leetcode-cn.com/problems/pancake-sorting/
    /// date: 20220219
    /// </summary>
    public static class Solution969
    {
        public static IList<int> PancakeSort(int[] arr) {
            void Reverse(int end) {
                for (int i = 0, j = end; i < j; i++, j--) {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            IList<int> ret = new List<int>();
            for (int n = arr.Length; n > 1; n--) {
                int index = 0;
                for (int i = 1; i < n; i++) {
                    if (arr[i] >= arr[index]) {
                        index = i;
                    }
                }
                if (index == n - 1) {
                    continue;
                }
                Reverse(index);
                Reverse(n - 1);
                ret.Add(index + 1);
                ret.Add(n);
            }
            return ret;
        }
    }
}
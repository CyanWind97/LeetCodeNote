using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 38
    /// title: 字符串的排列
    /// problems: https://leetcode-cn.com/problems/zi-fu-chuan-de-pai-lie-lcof/
    /// date: 20210622
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_38
    {
        // 参考解答 下一排列
        public static string[] Permutation(string s) {
            bool NextPermutation(char[] arr) {
                int i = arr.Length - 2;
                while (i >= 0 && arr[i] >= arr[i + 1]) {
                    i--;
                }
                if (i < 0) {
                    return false;
                }
                int j = arr.Length - 1;
                while (j >= 0 && arr[i] >= arr[j]) {
                    j--;
                }
                (arr[i], arr[j]) = (arr[j], arr[i]);
                Array.Reverse(arr, i + 1, arr.Length - i - 1);
                return true;
            }

            IList<string> ret = new List<string>();
            char[] arr = s.ToCharArray();
            Array.Sort(arr);

            do {
                ret.Add(new string(arr));
            } while (NextPermutation(arr));
            
            int size = ret.Count;
            string[] retArr = new string[size];
            for (int i = 0; i < size; i++) {
                retArr[i] = ret[i];
            }

            return retArr;
        }
    }
}
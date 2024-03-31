using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1089
    /// title: 复写零
    /// problems: https://leetcode.cn/problems/duplicate-zeros/
    /// date: 20220617
    /// </summary>
    public static class Solution1089
    {
        public static void DuplicateZeros(int[] arr) {
            int length = arr.Length;
            int top = 0;
            int i = -1;
            while (top < length) {
                i++;
                top++;
                if (arr[i] == 0) 
                    top++;
            }

            int j = length - 1;
            if (top == length + 1) {
                arr[j] = 0;
                j--;
                i--;
            } 

            while (j >= 0) {
                arr[j] = arr[i];
                j--;
                if (arr[i] == 0) {
                    arr[j] = arr[i];
                    j--;
                } 
                i--;
            }
        }
    }
}
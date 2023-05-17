using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1073
    /// title: 负二进制数相加
    /// problems: https://leetcode.cn/problems/adding-two-negabinary-numbers/
    /// date: 20230518
    /// </summary>
    public static class Solution1073
    {
        public static int[] AddNegabinary(int[] arr1, int[] arr2) {
            int l1 = arr1.Length;
            int l2 = arr2.Length;
            int max = Math.Max(l1, l2);
            var result = new int[max + 2];
            int carry = 0;
            for(int i = 1; i <= max || carry != 0; i++){
                int a = i <= l1 ? arr1[^i] : 0;
                int b = i <= l2 ? arr2[^i] : 0;
                int sum = a + b + carry;
                result[^i] = sum & 1;
                carry = -(sum >> 1);
            }

            // 去除前导零
            int start = 0;
            while(start < result.Length - 1 && result[start] == 0){
                start++;
            }

            return result[start..];
        }
    }
}
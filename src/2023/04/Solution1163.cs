using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1163
    /// title: 按字典序排在最后的子串
    /// problems: https://leetcode.cn/problems/last-substring-in-lexicographical-order/
    /// date: 20230424
    /// </summary>
    public static class Solution1163
    {
        // 参考解答
        // 双指针
        public static string LastSubstring(string s) {
            int length = s.Length;
            int i = 0; 
            int j = 1;
            while(j < length){
                int k = 0;
                while(j + k < length && s[i + k] == s[j + k]){
                    k++;
                }

                if(j + k < length && s[i + k] < s[j + k])
                    (i, j) = (j, Math.Max(j + 1, i + k + 1));
                else
                    j = j + k + 1;
            }

            return s.Substring(i);
        }
    }
}
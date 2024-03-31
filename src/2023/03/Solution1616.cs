using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1616
    /// title: 分割两个字符串得到回文串
    /// problems: https://leetcode.cn/problems/split-two-strings-to-make-palindrome/
    /// date: 20230318
    /// </summary>
    public static class Solution1616
    {
        public static bool CheckPalindromeFormation(string a, string b) {

            bool IsPalindrome(ReadOnlySpan<char> chars){
                int length = chars.Length;
                
                for(int i = 0; i < length / 2; i++){
                    if(chars[i] != chars[length - i - 1])
                        return false;
                }

                return true;
            }

            int length = a.Length;

            bool CheckCheckPalindrome(string s1, string s2){
                int index = 0;
                while(index < length && s1[index] == s2[length - index - 1]){
                    index++;
                }

                if(index >= length / 2)
                    return true;

                int subLength = length - 2 * index;
                if(IsPalindrome(s1.AsSpan().Slice(index, subLength))
                    || IsPalindrome(s2.AsSpan().Slice(index, subLength)))
                    return true;

                return false;
            }
                

            return CheckCheckPalindrome(a, b) || CheckCheckPalindrome(b, a);
        }
    }
}
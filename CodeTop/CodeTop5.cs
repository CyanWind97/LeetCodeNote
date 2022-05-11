using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 5
    /// title:  最长回文子串
    /// problems: https://leetcode.cn/problems/longest-palindromic-substring/
    /// date: 20220509
    /// priority: 0023
    /// time: timeout
    public static class CodeTop5
    {
        public static string LongestPalindrome(string s) {
            int length = s.Length;
            var dp = new bool[length, length];
            int start = 0;
            int maxL = 1;

            for(int i = 0; i < length - 1; i++){
                dp[i, i] = true;

                if(s[i] == s[i + 1]){
                    dp[i, i + 1] = true;

                    if(maxL == 1){
                        start = i;
                        maxL = 2;
                    }
                }
            }
            
            dp[length - 1, length - 1] = true;


            for(int l = 3; l <= length; l++){
                for(int i = 0; i <= length - l; i++){
                    int j = i + l - 1;
                    dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j];

                    if(dp[i, j] && l > maxL){
                        start = i;
                        maxL = l;
                    }
                }
            }

            return s.Substring(start, maxL);
        }


        // 参考解答 中心扩展 
        // 能想到， 但是不敢写
        public static string LongestPalindrome_1(string s){
            int length = s.Length;
            int start = 0;
            int maxL = 1;

            int Expand(int left, int right){
                while(left >= 0 && right < length && s[left] == s[right]){
                    left--;
                    right++;
                }

                return right - left - 1;
            }

            for(int i = 0; i < length - maxL / 2; i++){
                int l = Math.Max(Expand(i, i), Expand(i, i + 1));
                if(l > maxL){
                    start = i - (l - 1) / 2;
                    maxL = l;
                }
            }

            return s.Substring(start, maxL);
        }


        // 参考解答 Manacher
        public static string LongestPalindrome_2(string s){
            int length = s.Length;
            int start = 0; int end = -1;

            var sb = new StringBuilder();
            for(int i = 0; i < length; i++){
                sb.Append(s[i]);
                sb.Append('#');
            }
            sb.Append('#');
            s = sb.ToString();

            var armLen = new List<int>();
            int right = -1; 
            int j = -1;

            int Expand(int left, int right){
                while(left >= 0 && right < length && s[left] == s[right]){
                    left--;
                    right++;
                }

                return (right - left - 2) / 2;
            }

            for(int i = 0; i < length; i++){
                int curArmLen = 0;
                if(right >= i){
                    int iSym = 2 * j - i;
                    int minArmLen = Math.Min(armLen[iSym], right - i);
                    curArmLen = Expand(i - minArmLen, i + minArmLen);
                }else{
                    curArmLen = Expand(i, i);
                }

                armLen.Add(curArmLen);
                if(i + curArmLen > right){
                    j = i;
                    right = i + curArmLen;
                }

                if(curArmLen * 2 + 1 > end - start){
                    start = i - curArmLen;
                    end = i + curArmLen;
                }
            }

            sb.Clear();
            for(int i = start; i <= end; i++){
                if(s[i] != '#')
                    sb.Append(s[i]);
            }

            return sb.ToString();
        }
    }
}
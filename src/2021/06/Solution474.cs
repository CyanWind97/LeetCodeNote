using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 474
    /// title: 一和零
    /// problems: https://leetcode-cn.com/problems/ones-and-zeroes/
    /// date: 20210606
    /// </summary>
    public static class Solution474
    {
        public static int FindMaxForm(string[] strs, int m, int n) {
            int length = strs.Length;

            (int Zeros, int Ones) GetZerosOnes(string str){
                int zero = 0;
                foreach(var c in str){
                    if(c == '0')
                        zero++;
                }
                return (zero, str.Length - zero);
            }

            int[,] dp = new int[m + 1, n + 1];
            for(int i = 0; i < length; i++){
                (int zero, int one) = GetZerosOnes(strs[i]);
                for(int j = m; j >= zero; j--){
                    for(int k = n; k >= one; k--){
                        dp[j , k] = Math.Max(dp[j , k], dp[j - zero, k - one] + 1);
                    }
                }
            }


            return dp[m, n];
        }
    }
}
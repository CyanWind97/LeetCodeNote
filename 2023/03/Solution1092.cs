using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1092
    /// title: 最短公共超序列
    /// problems: https://leetcode.cn/problems/shortest-common-supersequence/
    /// date: 20230328
    /// </summary>
    public static class Solution1092
    {
        public static string ShortestCommonSupersequence(string str1, string str2) {
            int l1 = str1.Length;
            int l2 = str2.Length;
            
            var dp = new int[l1 + 1, l2 + 1];
            int i = 0;
            int j = 0;

            for(i = 0; i <= l1; i++){
                dp[i, l2] = l1 - i;
            }

            for(j = 0; j <= l2; j++){
                dp[l1, j] = l2 - j;
            }


            for(i = l1 - 1; i >= 0; i--){
                for(j = l2 - 1; j >= 0; j--){
                    dp[i, j] = str1[i] == str2[j]
                                ? dp[i + 1, j + 1]
                                : Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    dp[i, j]++;
                }
            }

            var sb = new StringBuilder();
            for(i = 0, j = 0; i < l1 && j < l2; ){
                if(str1[i] == str2[j]){
                    sb.Append(str1[i]);
                    i++;
                    j++;
                }else if(dp[i + 1, j] == dp[i, j] - 1){
                    sb.Append(str1[i]);
                    i++;
                }else if(dp[i, j + 1] == dp[i, j] - 1){
                    sb.Append(str2[j]);
                    j++;
                }
            }

            if(i < l1)
                sb.Append(str1.Substring(i));
            else if(j < l2)
                sb.Append(str2.Substring(j));

            return sb.ToString();
        }
    }
}
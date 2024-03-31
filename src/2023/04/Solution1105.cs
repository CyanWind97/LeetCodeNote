using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1105
    /// title: 填充书架
    /// problems: https://leetcode.cn/problems/filling-bookcase-shelves/
    /// date: 20230423
    /// </summary>
    public static class Solution1105
    {
        public static int MinHeightShelves(int[][] books, int shelfWidth) {
            int length = books.Length;
            var dp = new int[length + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            for(int i = 0; i < length; i++){
                int maxH = 0;
                int curW = 0;

                for(int j = i; j >= 0; j--){
                    curW += books[j][0];
                    if(curW > shelfWidth)
                        break;
                    
                    maxH = Math.Max(maxH, books[j][1]);
                    dp[i + 1] = Math.Min(dp[i + 1], dp[j] + maxH);
                }
            }

            return dp[length];
        }
    }
}
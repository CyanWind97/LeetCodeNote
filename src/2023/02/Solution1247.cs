using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1247
    /// title: 交换字符使得字符串相同
    /// problems: https://leetcode.cn/problems/minimum-swaps-to-make-strings-equal/
    /// date: 20230225
    /// </summary>
    public static class Solution1247
    {
        public static int MinimumSwap(string s1, string s2) {
            int n = s1.Length;
            int xyCount = 0;
            int yxCount = 0;
            for(int i = 0; i < n; i++){
                if(s1[i] == s2[i])
                    continue;
                
                if(s1[i] == 'x')
                    xyCount++;
                else
                    yxCount++;
            }

            if((xyCount + yxCount) % 2 == 1)
                return -1;
            
            return xyCount / 2 + yxCount / 2 + xyCount % 2 + yxCount % 2; 
        }
    }
}
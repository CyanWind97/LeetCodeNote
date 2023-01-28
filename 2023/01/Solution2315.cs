using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2315
    /// title: 统计星号
    /// problems: https://leetcode.cn/problems/count-asterisks/
    /// date: 20230129
    /// </summary>
    public static class Solution2315
    {
        public static int CountAsterisks(string s) {
            int length = s.Length;
            int count = 0;

            for(int i = 0; i < length; i++){
                if(s[i] == '*'){
                    count++;
                }else if(s[i] == '|'){
                    i++;
                    while(i < length && s[i] != '|'){
                        i++;
                    }
                }
            }

            return count;
        }
    }
}
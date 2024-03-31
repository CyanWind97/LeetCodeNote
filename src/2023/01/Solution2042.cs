using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2042
    /// title: 检查句子中的数字是否递增
    /// problems: https://leetcode.cn/problems/check-if-numbers-are-ascending-in-a-sentence/
    /// date: 20230103
    /// </summary>
    public static class Solution2042
    {
        public static bool AreNumbersAscending(string s) {
            int prev = 0;
            int num = 0;
            
            foreach(var c in s){
                if(char.IsDigit(c)){
                    num = num * 10 + c - '0';
                }else{
                    if(num == 0)
                        continue;

                    if(num <= prev)
                        return false;
                    
                    prev = num;
                    num = 0;
                }
            }

            if(num > 0 && num <= prev)
                return false;

            return true;
        }
    }
}
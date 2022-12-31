using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2351
    /// title: 第一个出现两次的字母
    /// problems: https://leetcode.cn/problems/first-letter-to-appear-twice/
    /// date: 20230101
    /// </summary>
    public static class Solution2351
    {
        public static char RepeatedCharacter(string s) {
            var repeat = new bool[26];

            foreach(var c in s){
                if(repeat[c - 'a'])
                    return c;
                else
                    repeat[c - 'a'] = true;
            }

            return 'a';
        }   
    }
}
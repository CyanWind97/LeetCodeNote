using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2490
    /// title: 回环句
    /// problems: https://leetcode.cn/problems/circular-sentence/
    /// date: 20230630
    /// </summary>
    public static class Solution2490
    {
        public static bool IsCircularSentence(string sentence) {
            if(sentence[^1] != sentence[0])
                return false;
            
            for(int i = 0; i < sentence.Length; i++){
                if (sentence[i] != ' ')
                    continue;
                
                if (sentence[i - 1] != sentence[i - 1])
                    return false;
            }

            return true;
        }
    }
}
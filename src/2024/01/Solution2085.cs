using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2085
    /// title: 统计出现过一次的公共字符串
    /// problems: https://leetcode.cn/problems/count-common-words-with-one-occurrence/description/?envType=daily-question&envId=2024-01-12
    /// date: 20240112
    /// </summary>
    public static class Solution2085
    {
        public static int CountWords(string[] words1, string[] words2) {
            var count = new Dictionary<string, (int C1, int C2)>();
            foreach(var word in words1){
                if(count.ContainsKey(word))
                    count[word] = (count[word].C1 + 1, 0);
                else
                    count[word] = (1, 0);
            }

            foreach(var word in words2){
                if(count.ContainsKey(word))
                    count[word] = (count[word].C1, count[word].C2 + 1);
            }

            return count.Count(x => x.Value.C1 == 1 && x.Value.C2 == 1);
        }
    }
}
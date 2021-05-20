using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 692
    /// title: 前K个高频单词
    /// problems: https://leetcode-cn.com/problems/top-k-frequent-words/
    /// date: 20210520
    /// </summary>
    public static class Solution692
    {
        public static IList<string> TopKFrequent(string[] words, int k) {
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach(string word in words){
                if(count.ContainsKey(word))
                    count[word]++;
                else
                    count.Add(word, 1);       
            }

            return count.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x => x.Key).ToList();
        }
    }
}
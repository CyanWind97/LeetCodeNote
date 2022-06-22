using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 30
    /// title: 串联所有单词的子串
    /// problems: https://leetcode.cn/problems/substring-with-concatenation-of-all-words/
    /// date: 20220623
    /// </summary>
    public static class Solution30
    {
        // 参考解答 滑动窗口
        // 有点思路， 但是有点没明白题目
        public static IList<int> FindSubstring(string s, string[] words) {
            int length = s.Length;
            int m = words.Length;
            int n = words[0].Length;

            var result = new List<int>();
            for(int i = 0; i < n; i++){
                if(i + m * n > length)
                    break;
                
                var differ = new Dictionary<string, int>();
                for(int j = 0; j < m; j++){
                    var word = s.Substring(i + j * n, n);
                    if(!differ.ContainsKey(word))
                        differ.Add(word, 0);
                    
                    differ[word]++;
                }

                foreach(var word in words){
                    if(!differ.ContainsKey(word))
                        differ.Add(word, 0);
                    
                    differ[word]--;
                    if(differ[word] == 0)
                        differ.Remove(word);
                }

                for(int start = i; start < length - m * n + 1; start += n){
                    if(start != i){
                        var word = s.Substring(start + (m - 1) * n, n);
                        if(!differ.ContainsKey(word))
                            differ.Add(word, 0);
                        
                        differ[word]++;
                        if(differ[word] == 0)
                            differ.Remove(word);
                        
                        word = s.Substring(start - n, n);
                        if(!differ.ContainsKey(word))
                            differ.Add(word, 0);
                        
                        differ[word]--;
                        if(differ[word] == 0)
                            differ.Remove(word);
                        
                        word = s.Substring(start - n, n);
                    }

                    if(differ.Count == 0)
                        result.Add(start);
                }
            }

            return result;
        }
    }
}
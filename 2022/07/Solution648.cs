using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 648
    /// title: 单词替换
    /// problems: https://leetcode.cn/problems/replace-words/
    /// date: 20220707
    /// </summary>
    public static class Solution648
    {
        public static string ReplaceWords(IList<string> dictionary, string sentence) {
            var dictionarySet = new HashSet<string>();
            foreach (string root in dictionary) {
                dictionarySet.Add(root);
            }
            string[] words = sentence.Split(" ");
            for (int i = 0; i < words.Length; i++) {
                string word = words[i];
                for (int j = 0; j < word.Length; j++) {
                    if (dictionarySet.Contains(word.Substring(0, 1 + j))) {
                        words[i] = word.Substring(0, 1 + j);
                        break;
                    }
                }
            }
            return string.Join(" ", words);
        }
    }
}
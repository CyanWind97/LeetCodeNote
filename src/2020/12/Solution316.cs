using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 316
    /// title: 去除重复字母
    /// problems: https://leetcode-cn.com/problems/remove-duplicate-letters/
    /// date: 20201220
    /// </summary>
    public static class Solution316
    {
        // 参考解答： 贪心 + 栈
        public static string RemoveDuplicateLetters(string s) {
            char[] chars = s.ToCharArray();
            int[] count = new int[26];
            bool[] exists = new bool[26];
            int length = chars.Length;
            List<char> result = new List<char>();
            foreach(char c in chars) {
                count[c-'a']++;
            }
            
            int index = 0;
            result.Add(chars[0]);
            count[chars[0]-'a']--;
            exists[chars[0] - 'a'] = true;
            for(int i = 1; i < length; i++) {
                char c = chars[i];
                if(!exists[c - 'a']){
                    while(index >= 0 && c < result[index] && count[result[index] - 'a'] > 0){
                        exists[result[index--] - 'a'] = false;
                    }
                    if(index < result.Count - 1){
                        result[++index] = c;
                    }else{
                        result.Add(c);
                        index++;
                    }
                    exists[c - 'a'] = true;
                }
                count[c - 'a']--;
            }
            
            return new string(result.ToArray());
        }

        // 官方解答
         public static string RemoveDuplicateLetters_1(string s) {
            var arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a'] = i;
            }

            var stack = new Stack<char>();
            var visited = new bool[26];
            for (int i = 0; i < s.Length; i++)
            {
                char item = s[i];
                if (visited[item - 'a'])
                    continue;

                while (stack.Any() && item < stack.Peek() && arr[stack.Peek() - 'a'] > i)
                {
                    var top = stack.Pop();
                    visited[top - 'a'] = false;
                }

                visited[item - 'a'] = true;
                stack.Push(item);
            }

            var sb = new StringBuilder();
            while (stack.Any())
            {
                sb.Insert(0, stack.Pop());
            }

            return sb.ToString();
        }
    }
}
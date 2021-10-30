using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 500
    /// title: 键盘行
    /// problems: https://leetcode-cn.com/problems/keyboard-row/
    /// date: 20211031
    /// </summary>
    public static class Solution500
    {
        public static string[] FindWords(string[] words) {
            int[] rows = new int[26]{1,2,2,1,0,1,1,1,0,1,1,1,2,2,0,0,0,0,1,0,0,2,0,2,0,2};

            int GetIndex(char c) => c > 'Z' ? c - 'a' : c - 'A';

            var result = new List<string>();
            
            foreach(var word in words){
                int row = rows[GetIndex(word[0])];
                bool flag = true;
                int length = word.Length;
                for(int i = 1; i < length; i++){
                    if (rows[GetIndex(word[i])] != row){
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    result.Add(word);
            }

            return result.ToArray();
        }
    }
}
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 784
    /// title: 字母大小写全排列
    /// problems: https://leetcode.cn/problems/letter-case-permutation/
    /// date: 20221030
    /// </summary>
    public static class Solution784
    {
        public static IList<string> LetterCasePermutation(string s) {
            var indexs = new List<int>();
            var chars = s.ToCharArray();
            var result = new List<string>();

            int length = chars.Length;
            for(int i = 0; i < length; i++){
                if(char.IsDigit(chars[i]))
                    continue;
                
                indexs.Add(i);
                chars[i] = char.ToLower(chars[i]);
            }

            int count = indexs.Count;

            void DFS(int i, bool toUpper){
                var c = chars[indexs[i]];
                if(toUpper)
                    chars[indexs[i]] = char.ToUpper(c);
                
                if(i == count - 1){
                    result.Add(new string(chars));
                }else{
                    DFS(i + 1, false);
                    DFS(i + 1, true);
                }

                chars[indexs[i]] = c;
            }
            
            if(count > 0){
                DFS(0, false);
                DFS(0, true);
            }else{
                result.Add(s);
            }

            return result;
        }
    }
}
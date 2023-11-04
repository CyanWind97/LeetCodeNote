using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 187
    /// title: 重复的DNA序列
    /// problems: https://leetcode-cn.com/problems/repeated-dna-sequences/
    /// date: 20211008
    /// </summary>

    public static partial class Solution187
    {
        public static IList<string> FindRepeatedDnaSequences(string s) {
            var result = new List<string>();
            int length = s.Length;
            
            if (length <= 10)
                return result;

            var dic = new Dictionary<string, bool>();

            for(int i = 0; i <= length - 10; i++){
                var key = s.Substring(i, 10);
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, true);
                }
                else if (dic[key])
                {
                    result.Add(key);
                    dic[key] = false;
                }
            }

            return result;
        }

        // 参考解答 滑动窗口 + 位运算
        public static IList<string> FindRepeatedDnaSequences_1(string s) {
            const int L = 10;
            var bin = new Dictionary<char, int> {
                {'A', 0}, {'C', 1}, {'G', 2}, {'T', 3}
            };

            IList<string> ans = new List<string>();
            int n = s.Length;
            if (n <= L) 
                return ans;
            
            int x = 0;
            for (int i = 0; i < L - 1; ++i) {
                x = (x << 2) | bin[s[i]];
            }

            var dic = new Dictionary<int, bool>();
            for (int i = 0; i <= n - L; ++i) {
                x = ((x << 2) | bin[s[i + L - 1]]) & ((1 << (L * 2)) - 1);
                if (!dic.ContainsKey(x)) {
                    dic.Add(x, true);
                } else if(dic[x]){
                    dic[x] = false;
                    ans.Add(s.Substring(i, L));
                }
            }

            return ans;
        }
    }
}
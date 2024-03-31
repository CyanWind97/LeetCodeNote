using System.Linq;
using System.Text;
using System.Collections.Generic;
using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 49
    /// title: 字母异位词分组
    /// problems: https://leetcode-cn.com/problems/group-anagrams/
    /// date: 20201214
    /// </summary>
    public static class Solution49
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs) {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach(string s in strs) {
                int[] keys = new int[26];
                foreach(char c in s) {
                    keys[c - 'a']++;
                }
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < keys.Length; i++) {
                    if(keys[i] > 0) 
                        sb.Append((char)(i + 'a')).Append(keys[i]);
                }
                string key = sb.ToString();
                if(!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(s);
            }
            
            return dic.Values.ToList();
        }

        // 排序
        public static IList<IList<string>> GroupAnagrams_1(string[] strs) {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach(string s in strs) {
                string key = new string(s.ToCharArray().OrderBy(x => x).ToArray());
                if(!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(s);
            }
            
            return dic.Values.ToList();
        }


        // 参考解答：质数积，样例字符长度不足
        public static IList<IList<string>> GroupAnagrams_2(string[] strs) {
            int[] charHash = {
                2,  3,  5,  7,  11, 
                13, 17, 19, 23, 29,
                31, 37, 41, 43, 47, 
                53, 59, 61, 67, 71,
                73, 79, 83, 89, 97, 
                101 
            } ;
            Dictionary<long, IList<string>> dic = new Dictionary<long, IList<string>>();
            foreach(string s in strs) {
                long key = 1;
                foreach(char c in s) {
                    key = key * charHash[c - 'a'];
                }
                if(!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(s);
            }
            
            return dic.Values.ToList();
        }

    }
}
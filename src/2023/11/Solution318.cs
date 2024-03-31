using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 318
    /// title: 最大单词长度乘积
    /// problems: https://leetcode.cn/problems/maximum-product-of-word-lengths/description/?envType=daily-question&envId=2023-11-06
    /// date: 20231106
    /// </summary>
    public static partial class Solution318
    {
        public static int MaxProduct_1(string[] words) {
            int GetKey(string word){
                int key = 0;
                foreach(var c in word){
                    key |= 1 << (c - 'a');
                }

                return key;
            }

            int length = words.Length;
            int max = 0;
            var dic = new Dictionary<int, int>();

            for(int i = 0; i < length; i++){
                int curLength = words[i].Length;
                var key = GetKey(words[i]);
                if (!dic.ContainsKey(key))
                    dic.Add(key, words[i].Length);
                else if (dic[key] < words[i].Length)
                    dic[key] = words[i].Length;
            }

            var infos = dic.ToList();
            for(int i = 0; i < infos.Count; i++){
                for(int j = 1; j < infos.Count; j++){
                    if ((infos[i].Key & infos[j].Key) == 0)
                        max = Math.Max(max, infos[i].Value * infos[j].Value);
                }
            }

            return max;  
        }
    }
}
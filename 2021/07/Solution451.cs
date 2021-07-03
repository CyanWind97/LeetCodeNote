using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 451
    /// title: 根据字符出现频率排序
    /// problems: https://leetcode-cn.com/problems/sort-characters-by-frequency/
    /// date: 20210703
    /// </summary>
    public static class Solution451
    {
        public static string FrequencySort(string s) {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach(char c in s){
                if(dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var pair in dic.OrderByDescending(x => x.Value)){
                for(int i = 0; i < pair.Value; i++){
                    sb.Append(pair.Key);
                }
            } 

            return sb.ToString();
        }
    }
}
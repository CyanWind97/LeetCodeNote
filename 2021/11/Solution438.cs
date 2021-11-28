using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 438
    /// title: 找到字符串中所有字母异位词
    /// problems: https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/
    /// date: 20211128
    /// </summary>
    public static class Solution438
    {
        public static IList<int> FindAnagrams(string s, string p) {
            var result = new List<int>();
            int length = s.Length;
            int left = 0;
            int pLength = p.Length;
            
            if (pLength > length)
                return result;

            var counts = p.GroupBy(x => x)
                          .ToDictionary(x => x.Key, x => x.Count());

            int next = 1;
            for(int i = 0; i < pLength; i++){
                if (counts.ContainsKey(s[i]))
                    counts[s[i]]--;
                else
                    next = i + 1;
            }

            if (counts.All(x => x.Value == 0))
                result.Add(left);
            
            
            while(left + pLength < length){
                while(left < next && left + pLength < length){
                    if (counts.ContainsKey(s[left]))
                        counts[s[left]]++;
                    
                    int right = left + pLength;

                    if(counts.ContainsKey(s[right]))
                        counts[s[right]]--;
                    else
                        next = right + 1;

                    left++;
                }

                if(counts.All(x => x.Value == 0))
                    result.Add(left);
                
                next++;
            }


            return result;
        }
    }
}
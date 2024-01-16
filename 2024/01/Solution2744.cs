using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2744
    /// title: 最大字符串配对数目
    /// problems: https://leetcode.cn/problems/find-maximum-number-of-string-pairs/description/?envType=daily-question&envId=2024-01-17
    /// date: 20240117
    /// </summary>
    public static class Solution2744
    {
        public static int MaximumNumberOfStringPairs(string[] words) {
            var count = new HashSet<int>();
            var result = 0;
            // 长度只有2; 
            foreach(var word in words){
                var key = word[0] - 'a' + (word[1] - 'a') * 26;
                if (count.Contains(key))
                    result++;
                else
                {
                    key = word[1] - 'a' + (word[0] - 'a') * 26;
                    count.Add(key);
                }
            }

            return result;
        }
    }
}
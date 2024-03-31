using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 942
    /// title: 增减字符串匹配
    /// problems: https://leetcode.cn/problems/di-string-match/
    /// date: 20220509
    /// </summary>
    public static class Solution942
    {
        public static int[] DiStringMatch(string s) {
            int length = s.Length;
            var list = new List<int>();
            
            list.Add(0);
            var index = 0;
            for(int i = 0; i < length; i++){
                if(s[i] == 'I')
                    index++;
                
                list.Insert(index, i + 1);
            }

            var result = new int[length + 1];
            for(int i = 0; i < length + 1; i++){
                result[list[i]] = i;
            }

            return result;
        }

        // 参考解答 贪心 双指针
        public static int[] DiStringMatch_1(string s) {
            int length = s.Length;
            var result = new int[length + 1];

            int low = 0;
            int high = length;

            for(int i = 0; i < length; i++){
                result[i] = s[i] == 'I' ? low++ : high--;
            }

            result[length] = low;

            return result;
        }
    }
}
using System.Collections.Generic;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 828
    /// title: 统计子串中的唯一字符
    /// problems: https://leetcode.cn/problems/count-unique-characters-of-all-substrings-of-a-given-string/
    /// date: 20220906
    /// </summary>
    public static partial class Solution828
    {
        // 参考解答
        public static int UniqueLetterString(string s) {
            var index = new Dictionary<char, IList<int>>();
            for (int i = 0; i < s.Length; i++) {
                if (!index.ContainsKey(s[i])) {
                    index.Add(s[i], new List<int>());
                    index[s[i]].Add(-1);
                }

                index[s[i]].Add(i);
            }
            int result = 0;
            foreach (var pair in index) {
                var arr = pair.Value;
                arr.Add(s.Length);
                for (int i = 1; i < arr.Count - 1; i++) {
                    result += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
                }
            }

            return result;
        }
    }
}
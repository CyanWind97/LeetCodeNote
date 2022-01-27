using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2047
    /// title: �����е���Ч������
    /// problems: https://leetcode-cn.com/problems/number-of-valid-words-in-a-sentence/
    /// date: 20220127
    /// </summary>
    public static class Solution2047
    {
        public static int CountValidWords(string sentence) {
            var regex = new Regex(@"^([a-z]+(-[a-z]+)?)?(!|\.|,)?$");

            return Regex.Split(sentence, @"\s+")
                        .Count(x => regex.IsMatch(x) && !string.IsNullOrEmpty(x));
        }

    }
}
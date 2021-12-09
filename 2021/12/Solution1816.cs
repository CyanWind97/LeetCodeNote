using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1816
    /// title:  截断句子
    /// problems: https://leetcode-cn.com/problems/truncate-sentence/
    /// date: 20211206
    /// </summary>
    public static class Solution1816
    {
        public static string TruncateSentence(string s, int k) {
            int length = s.Length;
            int index = 0;
            int count = 0;
            
            while(index < length && count < k){
                if(s[index] == ' ')
                    count++;
                
                index++;
            }

            return s.Substring(0, index - (count == k ? 1 : 0));
        }

        public static string TruncateSentence_1(string s, int k) {
            return string.Join(' ',  s.Split(' ').Take(k));
        }
    }
}
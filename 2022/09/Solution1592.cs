using System.Text;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1592
    /// title: 重新排列单词间的空格
    /// problems: https://leetcode.cn/problems/rearrange-spaces-between-words/
    /// date: 20220907
    /// </summary>
    public static class Solution1592
    {
        public static string ReorderSpaces(string text) {
            int length = text.Length;
            string[] words = text.Trim().Split(" ");
            int cntSpace = length;
            int wordCount = 0;
            foreach (string word in words) {
                if (word.Length > 0) {
                    cntSpace -= word.Length;
                    wordCount++;
                }
            }
            var sb = new StringBuilder();
            if (words.Length == 1) {
                sb.Append(words[0]);
                for (int i = 0; i < cntSpace; i++) {
                    sb.Append(' ');
                }

                return sb.ToString();
            }

            int perSpace = cntSpace / (wordCount - 1);
            int restSpace = cntSpace % (wordCount - 1);
            for (int i = 0; i < words.Length; i++) {
                if (words[i].Length == 0) {
                    continue;
                }
                if (sb.Length > 0) {
                    for (int j = 0; j < perSpace; j++) {
                        sb.Append(' ');
                    }
                }
                sb.Append(words[i]);
            }
            
            for (int i = 0; i < restSpace; i++) {
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 520
    /// title: 检测大写字母
    /// problems: https://leetcode-cn.com/problems/detect-capital/
    /// date: 20211113
    /// </summary>
    public class Solution520
    {
        public static bool DetectCapitalUse(string word) {
            int length = word.Length;
            bool isFirst = char.IsUpper(word[0]);
            int count = isFirst ? 1 : 0;
            
            for(int i = 1; i < length; i++){
                if(char.IsUpper(word[i]))
                    count++;
            }
            
            return (count == length || count == 0) || (count == 1 && isFirst);
        }
    }
}
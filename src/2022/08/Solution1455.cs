namespace LeetCodeNote
{
    /// <summary>
    /// no: 1455
    /// title:  检查单词是否为句中其他单词的前缀
    /// problems: https://leetcode.cn/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/
    /// date: 20220821
    /// </summary>
    public static class Solution1455
    {
        public static int IsPrefixOfWord(string sentence, string searchWord) {
            var words = sentence.Split(" ");
            var length = words.Length;

            for(int i = 0; i < length; i++){
                if(words[i].StartsWith(searchWord))
                    return i + 1;
            }

            return -1;
        }
    }
}
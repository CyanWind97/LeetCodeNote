namespace LeetCodeNote
{
    public static class Solution389
    {
        /// <summary>
        /// no: 389
        /// title: 找不同
        /// problems: https://leetcode-cn.com/problems/find-the-difference/
        /// date: 20201218
        /// </summary>
        public static char FindTheDifference(string s, string t) {
            int[] count = new int[26];
        
            foreach(char c in s) {
                count[c - 'a']++;
            }

            foreach(char c in t) {
                count[c - 'a']--;
                if(count[c - 'a'] < 0) {
                    return c;
                }
            }

            return 'a';
        }

        
        // 官方参靠解答：位运算
        public static char FindTheDifference_1(string s, string t) {
            int result = 0;
            foreach(char c in s) {
                result ^= c;
            }
            foreach(char c in t) {
                result ^= c;
            }

            return (char)result;
        }
    }
}
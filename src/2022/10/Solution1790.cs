namespace LeetCodeNote
{
    /// <summary>
    /// no: 1790
    /// title: 仅执行一次字符串交换能否使两个字符串相等
    /// problems: https://leetcode.cn/problems/check-if-one-string-swap-can-make-strings-equal/
    /// date: 20221011
    /// </summary>
    public static class Solution1790
    {
        public static bool AreAlmostEqual(string s1, string s2) {
            int length = s1.Length;

            if(length != s2.Length)
                return false;
            
            var indexs = new int[2];
            int j = 0;

            for(int i = 0; i < length; i++){
                if(s1[i] == s2[i])
                    continue;
                
                if(j == 2)
                    return false;
                
                indexs[j++] = i;
            }

            return (s1[indexs[0]] == s2[indexs[1]]) && (s1[indexs[1]] == s2[indexs[0]]);
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 28
    /// title: 实现 strStr()
    /// problems: https://leetcode-cn.com/problems/implement-strstr/
    /// date: 20210420
    /// </summary>
    public static class Solution28
    {
        public static int StrStr(string haystack, string needle)
        {
            char[] charsH = haystack.ToCharArray();
            char[] charsN = needle.ToCharArray();
            int lengthH = charsH.Length;
            int lengthN = charsN.Length;
            if(lengthN == 0)
                return 0;
            int[] next = new int[lengthN];
            next[0] = -1;
            int i = 0; 
            int j = -1;
            while(i < lengthN - 1){
                if(j == -1 || charsN[i] == charsN[j]){
                    i++;
                    j++;
                    next[i] = j;
                }else
                    j = next[j];
            }

            i = 0; j = 0;
            while(i < lengthH && j < lengthN){
                if(j == -1 || charsH[i] == charsN[j]){
                    i++;
                    j++;
                }else{
                    j = next[j];
                }
            }

            return j == lengthN ? i - j : - 1;
        }
    }
}
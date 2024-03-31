namespace LeetCodeNote
{
    /// <summary>
    /// no: 686
    /// title:  重复叠加字符串匹配
    /// problems: https://leetcode-cn.com/problems/repeated-string-match/
    /// date: 20211222
    /// </summary>
    public static class Solution686
    {
        // 参考解答 KMP
        public static int RepeatedStringMatch(string a, string b) {
            int aLength = a.Length, bLength = b.Length;

            int KMP() {
                if (bLength == 0) 
                    return 0;
                
                int[] pi = new int[bLength];
                for (int i = 1, j = 0; i < bLength; i++) {
                    while (j > 0 && b[i] != b[j]) {
                        j = pi[j - 1];
                    }
                    if (b[i] == b[j]) 
                        j++;
                    
                    pi[i] = j;
                }

                for (int i = 0, j = 0; i - j < aLength; i++) { // b 开始匹配的位置是否超过第一个叠加的 a
                    while (j > 0 && a[i % aLength] != b[j]) { // a 是循环叠加的字符串，所以取 i % aLength
                        j = pi[j - 1];
                    }
                    if (a[i % aLength] == b[j]) {
                        j++;
                    }
                    if (j == bLength) {
                        return i - bLength + 1;
                    }
                }

                return -1;
            }


            int index = KMP();

            if (index == -1) 
                return -1;
            
            if (aLength - index >= bLength) 
                return 1;
            
            return (bLength + index - aLength - 1) / aLength + 2;
        }
    }
}
namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 91
    /// title:   解码方法
    /// problems: https://leetcode.cn/problems/decode-ways/
    /// date: 20220512
    /// priority: 0037
    /// time: 00:09:43.45 timeout
    /// </summary>
    public class CodeTop91
    {
        public static int NumDecodings(string s) {
            int length = s.Length;
            int a = 0;
            int b = 1;
            int c = 0;

            for(int i = 0; i < length; i++){
                c = 0;
                if(s[i] != '0')
                    c += b;
                
                if(i > 0 && s[i - 1] != '0' && ((s[i - 1] - '0') * 10 + (s[i] - '0') <= 26))
                    c += a;
                
                (a, b) = (b, c);
            }

            return c;
        }
    }
}
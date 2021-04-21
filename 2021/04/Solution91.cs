using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 91
    /// title: 解码方法
    /// problems: https://leetcode-cn.com/problems/decode-ways/
    /// date: 20210421
    /// </summary>
    public static class Solution91
    {
        // 绕远了
        public static int NumDecodings(string s) 
        {
            int n = s.Length;
            int[] count = new int[n + 1];
            count[0] = 1;
            count[1] = 1;
            for(int i = 2; i <= n; i++){
                count[i] = count[i - 1] + count[i - 2];
            }

            int NumDecodings(ReadOnlySpan<char> span, bool flag)
            {
                int length = span.Length;
                if(length == 0)
                    return 1;

                if(span[0] == '0')
                    return 0;
                
                if(length == 1)
                    return 1;

                if(!flag){
                    int i = 0;
                    while(i < length && (span[i] == '1' || span[i] == '2')){
                        i++;
                    }
                    
                    if(i == length)
                        return NumDecodings(span.Slice(0, length), true);
                    else
                        return NumDecodings(span.Slice(0, i + 1), true) * NumDecodings(span.Slice(i + 1), false);
                }else{
                    if(span[length -1] == '0')
                        return count[length - 2];
                    
                    if(span[length - 2] == '2' && span[length - 1] - '6' > 0)
                        return count[length - 1];
                    
                    return count[length];
                }
            }
        
            return NumDecodings(s.AsSpan(), false);
        }


        // 参考解答 动态规划
        public static int NumDecodings_1(string s){
            int length = s.Length;
            int a = 0;
            int b = 1;
            int c = 0;

            for(int i = 1; i <= length; i++){
                c = 0;
                if(s[i - 1] != '0')
                    c += b;
                
                if(i > 1 && s[i - 2] != '0' && ((s[i - 2] - '0') * 10 + (s[i - 1] - '0') <= 26))
                    c += a;
                
                (a, b) = (b, c);
            }

            return c;
        }
    }
}
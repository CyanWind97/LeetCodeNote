using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 838
    /// title: 推多米诺
    /// problems: https://leetcode-cn.com/problems/push-dominoes/
    /// date: 20220221
    /// </summary>
    public static class Solution838
    {
        public static string PushDominoes(string dominoes) {
            var chars = dominoes.ToCharArray();
            int length = chars.Length;
            int pre = 0;
            for(int i = 1; i < length; i++){
                if(pre == i || chars[i] == '.')
                    continue;
                    
                int left = pre;
                int right = i;
                if(chars[i] == chars[pre] || (chars[pre] == '.' && chars[i] == 'L')){
                    if(chars[i] == 'L')
                        right = pre;
                    else if(chars[i] == 'R')
                        left = i;
                }else if(chars[i] == 'R'){
                    left = i;
                    right = pre;
                }else{
                    int mid = (pre + i) / 2;
                    left = mid + 1;
                    right = mid - ((pre + i - 2 * mid) ^ 1);
                }

                Array.Fill(chars, 'L', left, Math.Max(0, i -  left));
                Array.Fill(chars, 'R', pre + 1, Math.Max(0, right - pre ));

                pre = chars[i] != 'R' ? i + 1 : i;
            }
            
            if(pre < length && chars[pre] == 'R')
                Array.Fill(chars, 'R', pre + 1, Math.Max(0, length - pre - 1));
            
            return new string(chars);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 564
    /// title: 寻找最近的回文数
    /// problems: https://leetcode-cn.com/problems/find-the-closest-palindrome/
    /// date: 20220302
    /// </summary>
    public static class Solution564
    {
        public static string NearestPalindromic(string n) {
            if(n.Length == 1)
                return (int.Parse(n) - 1).ToString();
            
            if(long.Parse(n) == (long)Math.Pow(10, n.Length-1) || long.Parse(n) - 1 == (long)Math.Pow(10, n.Length-1))
                return ((long)Math.Pow(10, n.Length-1) - 1).ToString();

            int l = n.Length / 2;
            int odevity = n.Length % 2;
            int c = 0;
            bool isNineForm = false;
            var span = n.AsSpan();
            var left = span.Slice(0, l);
            var right = span.Slice(l + odevity, l);

            if((long)Math.Pow(10,n.Length) - long.Parse(n) == 1)
                isNineForm = true;
                
            char[] tmp = left.ToArray();
            Array.Reverse(tmp);
            
            long sub = long.Parse(tmp) - long.Parse(right);

            if( sub == 0){   
                if(isNineForm || (odevity == 1 && span[l] == '0'))
                    c = 1;
                else
                    c = -1;
            }else if( sub < 0){
                long dValue =(long) Math.Pow(10,right.Length) + ((odevity+1)%2)* (long)Math.Pow(10,right.Length-1) + sub;
                if( dValue < -sub)
                    c = 1;
            }else{
                long dValue =(long) Math.Pow(10,right.Length) + (long)Math.Pow(10,right.Length-1) - sub;
                if (dValue <= sub)
                    c = -1;
            }

            if( odevity == 1 )
                left =  string.Concat(left, span.Slice(l, odevity));
            
            
            left  = (long.Parse(left)+c).ToString();

            if(isNineForm){
                if(odevity == 1)
                    left = left.Slice(0,left.Length - 1);
                odevity = (odevity + 1) % 2;
            }

            tmp = left.ToArray();
            Array.Reverse(tmp);
            right = new string(tmp);
            
            left =  string.Concat(left, right.Slice(odevity, right.Length - odevity));

            return left.ToString();
        }

    }
}
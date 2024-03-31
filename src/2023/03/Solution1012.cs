using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1512
    /// title: 至少有 1 位重复的数字
    /// problems: https://leetcode.cn/problems/numbers-with-repeated-digits/
    /// date: 20230320
    /// </summary>
    public static class Solution1012
    {
        public static int NumDupDigitsAtMostN(int n) {
            var num = n.ToString();
            
            int A(int x, int y){
                int result = 1;
                for(int i = 0; i < x; i++){
                    result *= y--;
                }

                return result;
            }

            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }

            int F(int mask, int i, bool same){
                if(i == num.Length)
                    return 1;
                
                int t = same ? num[i] - '0' : 9;
                int result = 0;
                int c = BitCount(mask) + 1;
                for(int k = 0; k <= t; k++){
                    if((mask & (1 << k)) != 0)
                        continue;
                    
                    if(same && k == t)
                        result += F(mask | (1 << t), i + 1, true);
                    else if(mask == 0 && k == 0)
                        result += F(0, i + 1, false);
                    else 
                        result += A(num.Length - 1 - i, 10 - c);
                }

                return result;
            }

            return n + 1 - F(0, 0, true);
        }

    }
}
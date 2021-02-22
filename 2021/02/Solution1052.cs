using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1052
    /// title: 爱生气的书店老板
    /// problems: https://leetcode-cn.com/problems/grumpy-bookstore-owner/
    /// date: 20210223
    /// </summary>
    public static class Solution1052
    {
        public static int MaxSatisfied(int[] customers, int[] grumpy, int X) {
            int length = customers.Length;
            int max = 0;
            int sum = 0;
            int cur = 0;
            
            for(int i = 0; i < X; i++){
                if(grumpy[i] == 1)
                    cur += customers[i];
                else
                    sum += customers[i];
            }

            max = cur;

            for(int i = X; i < length; i++){
                if(grumpy[i - X] == 1)
                    cur -= customers[i - X];
                
                if(grumpy[i] == 1)
                    cur += customers[i];
                else
                    sum += customers[i];
                
                max = Math.Max(max, cur);
            }

            return sum + max;
        }
    }
}
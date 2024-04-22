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
    public static partial class Solution1052
    {
        public static int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
            int length = customers.Length;
            int max = 0;
            int sum = 0;
            int cur = 0;
            
            for(int i = 0; i < minutes; i++){
                if(grumpy[i] == 1)
                    cur += customers[i];
                else
                    sum += customers[i];
            }

            max = cur;

            for(int i = minutes; i < length; i++){
                if(grumpy[i - minutes] == 1)
                    cur -= customers[i - minutes];
                
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
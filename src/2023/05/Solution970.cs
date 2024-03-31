using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 970
    /// title:  强整数
    /// problems: https://leetcode.cn/problems/powerful-integers/
    /// date: 20230502
    /// </summary>
    public static class Solution970
    {
        public static IList<int> PowerfulIntegers(int x, int y, int bound) {
            var set = new HashSet<int>();
            int value1 = 1;
            for (int i = 0; i < 21; i++) {
                int value2 = 1;
                for (int j = 0; j < 21; j++) {
                    int value = value1 + value2;
                    if (value <= bound) 
                        set.Add(value);
                    else 
                        break;
                    
                    value2 *= y;
                }
                if (value1 > bound) 
                    break;
                
                value1 *= x;
            }

            return new List<int>(set);
        }
    }
}
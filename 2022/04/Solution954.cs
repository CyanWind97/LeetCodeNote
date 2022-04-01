using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 954
    /// title: 二倍数对数组
    /// problems: https://leetcode-cn.com/problems/array-of-doubled-pairs/
    /// date: 20220401
    /// </summary>
    public class Solution954
    {
        public static bool CanReorderDoubled(int[] arr) {
            var lookup = new Dictionary<int, int>();

            foreach(var num in arr){
                if(lookup.ContainsKey(num))
                    lookup[num]++;
                else
                    lookup.Add(num, 1);
            }

            var keys = lookup.Keys.OrderBy(x => x, Comparer<int>.Create((a , b) =>  Math.Abs(a) - Math.Abs(b)));

            foreach(var key in keys){
                var value = lookup[key];
                if(value == 0)
                    continue;

                if(key == 0)
                    if(value % 2 != 0)
                        return false;
                    else
                        continue;
                    
                var next = key * 2;

                if(!lookup.ContainsKey(next) || lookup[next] < value)
                    return false;
                
                lookup[next] -= value;
            }

            return true;
        }
    }
}
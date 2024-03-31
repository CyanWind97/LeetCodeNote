using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1488
    /// title: 避免洪水泛滥
    /// problems: https://leetcode.cn/problems/avoid-flood-in-the-city/?envType=daily-question&envId=2023-10-13
    /// date: 20231013
    /// </summary>
    public static class Solution1488
    {
        public static int[] AvoidFlood(int[] rains) {
            int length = rains.Length;
            int[] result = new int[length];
            var fullLakes = new SortedDictionary<int, int>();
            var emptyLakes = new SortedSet<int>();
            for(int i = 0; i < length; i++){
                int lake = rains[i];
                if(lake == 0){
                    emptyLakes.Add(i);
                    result[i] = 1;
                }else{
                    if(fullLakes.ContainsKey(lake)){
                        var emptyLake = emptyLakes.GetViewBetween(fullLakes[lake], i).FirstOrDefault(-1);
                        if(emptyLake == -1)
                            return Array.Empty<int>();
                        
                        result[emptyLake] = lake;
                        emptyLakes.Remove(emptyLake);
                    }
                    
                    fullLakes[lake] = i;
                    result[i] = -1;
                }
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2300
    /// title: 咒语和药水的成功对数
    /// problems: https://leetcode.cn/problems/successful-pairs-of-spells-and-potions/description/?envType=daily-question&envId=2023-11-10
    /// date: 20231110
    /// </summary>
    public static class Solution2300
    {
        public static int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
            int length = spells.Length;
            int pLength = potions.Length;
            Array.Sort(potions);
            var result = new int[length];

            for(int i = 0; i < length; i++){
                long t = (success + spells[i] - 1) / spells[i] - 1;
                int index = Array.BinarySearch(potions, (int)t);
                if(index < 0)
                    index = ~index;

                while(index < pLength && potions[index] <= t)
                    index++;
                
                result[i] = pLength - index;
            }

            return result;
        }
    }
}
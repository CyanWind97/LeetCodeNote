using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2645
    /// title: 构造有效字符串的最少插入数
    /// problems: https://leetcode.cn/problems/minimum-additions-to-make-valid-string/description/?envType=daily-question&envId=2024-01-11
    /// date: 20240111
    /// </summary>

    public static class Solution2645
    {
        public static int AddMinimum(string word) {
            int count = 0;
            var prev = 'c';
            foreach(var c in word){
                if (prev == c)
                    count += 2;
                else if ((prev - c + 3) % 3 == 1)
                    count++;

                prev = c;
            }

            if (prev != 'c')
                count += prev == 'a' ? 2 : 1;

            return count;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1189
    /// title: “气球” 的最大数量
    /// problems: https://leetcode-cn.com/problems/maximum-number-of-balloons/
    /// date: 20220213
    /// </summary>
    public static class Solution1189
    {
        public static int MaxNumberOfBalloons(string text) {
            int[] count = new int[26];
            foreach(var c in text){
                count[c - 'a']++;
            }

            IEnumerable<int> GetCounts(){
                yield return count['a' - 'a'];
                yield return count['b' - 'a'];
                yield return count['l' - 'a'] / 2;
                yield return count['o' - 'a'] / 2;
                yield return count['n' - 'a'];
            }

            return GetCounts().Min();
        }
    }
}
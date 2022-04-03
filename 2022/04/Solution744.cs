using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 744
    /// title: 寻找比目标字母大的最小字母
    /// problems: https://leetcode-cn.com/problems/find-smallest-letter-greater-than-target/
    /// date: 20220403
    /// </summary>
    public static class Solution744
    {
        public static char NextGreatestLetter(char[] letters, char target) {
            if(target >= letters.Last())
                return letters.First();
            
            var index = Array.BinarySearch(letters, target);
            if(index < 0)
                index = ~index;
            else
                while(letters[index] == target)
                    index++;
            
            return letters[index];
        }
    }
}
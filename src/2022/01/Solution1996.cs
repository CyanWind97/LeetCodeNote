using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1996
    /// title: 游戏中弱角色的数量
    /// problems: https://leetcode-cn.com/problems/the-number-of-weak-characters-in-the-game/
    /// date: 20220128
    /// </summary>
    public static class Solution1996
    {
        public static int NumberOfWeakCharacters(int[][] properties) {
            Array.Sort(properties, (a,b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);

            int count = 0;
            var stack = new Stack<int>();

            foreach(var p in properties){
                while(stack.Count > 0 && stack.Peek() < p[1]){
                    stack.Pop();
                    count++;
                }

                stack.Push(p[1]);
            }

            return count;
        }
    }
}
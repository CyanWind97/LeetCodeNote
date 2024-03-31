using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 789
    /// title: 逃脱阻碍者
    /// problems: https://leetcode-cn.com/problems/escape-the-ghosts/
    /// date: 20210822
    /// </summary>
    public static class Solution789
    {
        public static bool EscapeGhosts(int[][] ghosts, int[] target) {
            int ManhattanDistance(int[] point1, int[] point2)
                => Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);

            int[] source = {0, 0};
            int distance = ManhattanDistance(source, target);
            foreach (int[] ghost in ghosts) {
                int ghostDistance = ManhattanDistance(ghost, target);
                if (ghostDistance <= distance)
                    return false;
                
            }
            
            return true;
        }
    }
}
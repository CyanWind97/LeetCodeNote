using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1041
    /// title: 困于环中的机器人
    /// problems: https://leetcode.cn/problems/robot-bounded-in-circle/
    /// date: 20230411
    /// </summary>
    public static class Solution1041
    {
        public static bool IsRobotBounded(string instructions) {
            var dir = new (int X, int Y)[]{(0, 1), (1, 0), (0, -1), (-1, 0)};
            int dirIndex = 0;
            (int x, int y) = (0, 0);
            int n = instructions.Length;
            for(int i = 0; i < n; i++){
                var instruction = instructions[i];
                if(instruction == 'G'){
                    x += dir[dirIndex].X;
                    y += dir[dirIndex].Y;
                }else if(instruction == 'L'){
                    dirIndex += 3;
                    dirIndex %= 4;
                }else{
                    dirIndex++;
                    dirIndex %= 4;
                }
            }

            return dirIndex != 0 || (x == 0 && y == 0);
        }
    }
}
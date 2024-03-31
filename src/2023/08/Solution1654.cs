using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1654
    /// title: 到家的最少跳跃次数
    /// problems: https://leetcode.cn/problems/minimum-jumps-to-reach-home/
    /// date: 20230830
    /// </summary>
    public static class Solution1654
    {   
        // 参考解答
        // 广度有先
        public static int MinimumJumps(int[] forbidden, int a, int b, int x) {
            var queue = new Queue<(int Position, int Direction, int Step)>();
            var visited = new HashSet<int>();
            queue.Enqueue((0, 1, 0));
            visited.Add(0);

            int lower = 0, upper = Math.Max(forbidden.Max() + a, x) + b;
            var forbiddenSet =  forbidden.ToHashSet();

            while (queue.Count > 0) {
                (int position, int direction, int step) = queue.Dequeue();
                if (position == x) {
                    return step;
                }
                int nextPosition = position + a;
                int nextDirection = 1;
                if (lower <= nextPosition && nextPosition <= upper 
                && !visited.Contains(nextPosition * nextDirection) 
                && !forbiddenSet.Contains(nextPosition)) {
                    visited.Add(nextPosition * nextDirection);
                    queue.Enqueue((nextPosition, nextDirection, step + 1));
                }
                if (direction == 1) {
                    nextPosition = position - b;
                    nextDirection = -1;
                    if (lower <= nextPosition && nextPosition <= upper 
                    && !visited.Contains(nextPosition * nextDirection) 
                    && !forbiddenSet.Contains(nextPosition)) {
                        visited.Add(nextPosition * nextDirection);
                        queue.Enqueue((nextPosition, nextDirection, step + 1));
                    }
                }
            }

            return -1;
        }   
    }
}
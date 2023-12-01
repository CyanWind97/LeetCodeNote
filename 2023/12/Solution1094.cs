using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1094
    /// title: 拼车
    /// problems: https://live.bilibili.com/21624892?broadcast_type=0&live_from=72001&visit_id=c2b0kwopk680
    /// date: 20231202
    /// </summary>
    public static class Solution1094
    {
        public static bool CarPooling(int[][] trips, int capacity) {
            var pq = new PriorityQueue<(int Pos, int Num), int>();

            foreach(var trip in trips){
                (int num, int from, int to) = (trip[0], trip[1], trip[2]);
                pq.Enqueue((from, num), from);
                pq.Enqueue((to, -num), to);
            }

            int curr = 0;
            while(pq.Count > 0){
                var (pos, delta) = pq.Dequeue();
                while(pq.Count > 0 && pq.Peek().Pos == pos){
                    delta += pq.Dequeue().Num;
                }

                curr += delta;
                if (curr > capacity)
                    return false;
            }

            return true;
        }
    }
}
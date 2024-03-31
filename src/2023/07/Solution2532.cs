using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2532
    /// title:  过桥的时间
    /// problems: https://leetcode.cn/problems/time-to-cross-a-bridge/
    /// date: 20230707
    /// </summary>
    public static class Solution2532
    {
        // 参考解答
        // 优先队列
        public static int FindCrossingTime(int n, int k, int[][] time) {
            // 定义等待中的工人优先级比较规则，时间总和越高，效率越低，优先级越低，越优先被取出
            var waitLeft = new PriorityQueue<int, long>();
            var waitRight = new PriorityQueue<int, long>();

            var workLeft = new PriorityQueue<int[], long>();
            var workRight = new PriorityQueue<int[], long>();

            int remain = n, curTime = 0;
            for (int i = 0; i < k; i++) {
                long priority = -(time[i][0] + time[i][2]) * (long) 1001 - i;
                waitLeft.Enqueue(i, priority);
            }
            while (remain > 0 || workRight.Count > 0 || waitRight.Count > 0) {
                // 1. 若 workLeft 或 workRight 中的工人完成工作，则将他们取出，并分别放置到 waitLeft 和 waitRight 中。
                while (workLeft.Count > 0 && workLeft.Peek()[0] <= curTime) {
                    int val = workLeft.Dequeue()[1];
                    long priority = -(time[val][0] + time[val][2]) * (long) 1001 - val;
                    waitLeft.Enqueue(val, priority);
                }
                while (workRight.Count > 0 && workRight.Peek()[0] <= curTime) {
                    int val = workRight.Dequeue()[1];
                    long priority = -(time[val][0] + time[val][2]) * (long) 1001 - val;
                    waitRight.Enqueue(val, priority);
                }

                if (waitRight.Count > 0) {
                    // 2. 若右侧有工人在等待，则取出优先级最低的工人并过桥
                    int id = waitRight.Dequeue();
                    curTime += time[id][2];
                    long priority = (curTime + time[id][3]) * (long) 1001 + id;
                    workLeft.Enqueue(new int[]{curTime + time[id][3], id}, priority);
                } else if (remain > 0 && waitLeft.Count > 0) {
                    // 3. 若右侧还有箱子，并且左侧有工人在等待，则取出优先级最低的工人并过桥
                    int id = waitLeft.Dequeue();
                    curTime += time[id][0];
                    long priority = (curTime + time[id][1]) * (long) 1001 + id;
                    workRight.Enqueue(new int[]{curTime + time[id][1], id}, priority);
                    remain--;
                } else {
                    // 4. 否则，没有人需要过桥，时间过渡到 workLeft 和 workRight 中的最早完成时间
                    int nextTime = int.MaxValue;
                    if (workLeft.Count > 0) {
                        nextTime = Math.Min(nextTime, workLeft.Peek()[0]);
                    }
                    if (workRight.Count > 0) {
                        nextTime = Math.Min(nextTime, workRight.Peek()[0]);
                    }
                    if (nextTime != int.MaxValue) {
                        curTime = Math.Max(nextTime, curTime);
                    }
                }
            }
            
            return curTime;
        }
    }
}
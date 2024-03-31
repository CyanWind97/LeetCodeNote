using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 933
    /// title:  最近的请求次数
    /// problems: https://leetcode-cn.com/problems/number-of-recent-calls/
    /// date: 20220506
    /// </summary>
    public static class Solution933
    {
        public class RecentCounter {

            private Queue<int> _queue;

            public RecentCounter() {
                _queue = new Queue<int>();
            }
            
            public int Ping(int t) {
                _queue.Enqueue(t);

                while(_queue.Peek() < t - 3000){
                    _queue.Dequeue();
                }

                return _queue.Count;
            }
        }

    }
}
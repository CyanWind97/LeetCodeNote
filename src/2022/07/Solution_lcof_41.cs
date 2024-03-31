using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 041
    /// title: 滑动窗口的平均值
    /// problems: https://leetcode.cn/problems/qIsx9U/
    /// date: 20220716
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_041
    {
        public class MovingAverage {
            private Queue<int> _queue;
            private double _sum;

            private int _size;

            /** Initialize your data structure here. */
            public MovingAverage(int size) {
                _queue = new();
                _size = size;
                _sum = 0;
            }
            
            public double Next(int val) {
                if(_queue.Count == _size)
                    _sum -= _queue.Dequeue();

                _queue.Enqueue(val);
                _sum += val;
                
                return _sum / _queue.Count;
            }
        }
    }
}
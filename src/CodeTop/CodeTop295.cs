using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 295
    /// title:  数据流的中位数
    /// problems: https://leetcode.cn/problems/find-median-from-data-stream/
    /// date: 20220515
    /// priority: 0056
    /// time: 00:11:04.49
    /// </summary>
    public static class CodeTop295
    {
        public class MedianFinder {
            private PriorityQueue<int, int> _minQueue;
            private PriorityQueue<int, int> _maxQueue;

            public MedianFinder() {
                _minQueue = new PriorityQueue<int, int>();
                _maxQueue = new PriorityQueue<int, int>();
            }
            
            public void AddNum(int num) {
                if(_minQueue.Count == 0 || num <= _minQueue.Peek()){
                    _minQueue.Enqueue(num, -num);
                    if(_minQueue.Count - _maxQueue.Count > 1){
                        var tmp = _minQueue.Dequeue();
                        _maxQueue.Enqueue(tmp, tmp);
                    }
                }else{
                    _maxQueue.Enqueue(num, num);
                    if(_maxQueue.Count - _minQueue.Count > 0){
                        var tmp = _maxQueue.Dequeue();
                        _minQueue.Enqueue(tmp, -tmp);
                    }
                }
            }
            
            public double FindMedian() {
                if(_maxQueue.Count == _minQueue.Count)
                    return (_maxQueue.Peek() + _minQueue.Peek()) / 2.0;
                else
                    return _minQueue.Peek();
            }
        }
    }
}
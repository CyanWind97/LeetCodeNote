namespace LeetCodeNote
{
    /// <summary>
    /// no: 622
    /// title:  设计循环队列
    /// problems: https://leetcode.cn/problems/design-circular-queue/
    /// date: 20220802
    /// </summary>
    public static class Solution622
    {
        public class MyCircularQueue {
            
            private int[] _nums;
            private int _count;

            private int _size;
            private int _head;


            public MyCircularQueue(int k) {
                _nums = new int[k];
                _size = k;
                _count = 0;
                _head = 0;
            }
            
            public bool EnQueue(int value) {
                if(IsFull())
                    return false;
                
                _nums[(_head + _count) % _size] = value;
                _count++;

                return true;
            }
            
            public bool DeQueue() {
                if(IsEmpty())
                    return false;

                _head = (_head + 1) % _size;
                _count--;

                return true;
            }
            
            public int Front() {
                return IsEmpty() ? -1 : _nums[_head];
            }
            
            public int Rear() {
                return IsEmpty() ? -1 : _nums[(_head + _count - 1) % _size];
            }
            
            public bool IsEmpty() {
                return  _count == 0;
            }
            
            public bool IsFull() {
                return _count == _size;
            }
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 641
    /// title:  设计循环双端队列
    /// problems: https://leetcode.cn/problems/design-circular-deque/
    /// date: 20220815
    /// </summary>
    public static class Solution641
    {
        public class MyCircularDeque {
            private int[] _nums;
            private int _count;

            private int _size;
            private int _head;


            public MyCircularDeque(int k) {
                _nums = new int[k];
                _size = k;
                _count = 0;
                _head = 0;
            }
            
            public bool InsertFront(int value) {
                if(IsFull())
                    return false;
                
                _head = (_head - 1 + _size) % _size;
                _nums[_head] = value;
                _count++;

                return true;
            }
            
            public bool InsertLast(int value) {
                if(IsFull())
                    return false;
                
                _nums[(_head + _count) % _size] = value;
                _count++;

                return true;
            }
            
            public bool DeleteFront() {
                if(IsEmpty())
                    return false;

                _head = (_head + 1) % _size;
                _count--;

                return true;
            }
            
            public bool DeleteLast() {
                if(IsEmpty())
                    return false;

                _count--;

                return true;
            }
            
            public int GetFront() {
                return IsEmpty() ? -1 : _nums[_head];
            }
            
            public int GetRear() {
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
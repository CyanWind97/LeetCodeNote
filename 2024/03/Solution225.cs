using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 225
/// title: 用队列实现栈
/// problems: https://leetcode.cn/problems/implement-stack-using-queues/description/?envType=daily-question&envId=2024-03-03
/// date: 20240303
/// </summary> 
public static class Solution225
{
    public class MyStack {

        private Queue<int> _queue1 = new ();

        private Queue<int> _queue2 = new ();

        public MyStack() {
        }
        
        public void Push(int x) {
            _queue2.Enqueue(x);
            while (_queue1.Count > 0){
                _queue2.Enqueue(_queue1.Dequeue());
            }

            (_queue1, _queue2) = (_queue2, _queue1);
        }
        
        public int Pop() {
            return _queue1.Dequeue();
        }
        
        public int Top() {
            return _queue1.Peek();
        }
        
        public bool Empty() {
            return _queue1.Count == 0;
        }
    }

}

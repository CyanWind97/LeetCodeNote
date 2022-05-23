using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 155
    /// title:  最小栈
    /// problems: https://leetcode.cn/problems/min-stack/
    /// date: 20220523
    /// priority: 0096
    /// time: 00:21:26.45 timeout
    /// </summary>
    public static class CodeTop155
    {
        public class MinStack {
            private Stack<int> _stack;
            private Stack<int> _mins;


            public MinStack() {
                _stack = new Stack<int>();
                _mins = new Stack<int>();
            }
            
            public void Push(int val) {
                _stack.Push(val);
                if(!_mins.TryPeek(out int min) || min >= val)
                    _mins.Push(val);
                else
                    _mins.Push(min);
            }
            
            public void Pop() {
                _stack.Pop();
                _mins.Pop();
            }
            
            public int Top() {
               return _stack.Peek();
            }
            
            public int GetMin() {
               return  _mins.Peek();
            }
        }
    }
}
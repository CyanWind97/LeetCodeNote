using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 155
    /// title: 最小栈
    /// problems: https://leetcode-cn.com/problems/min-stack/
    /// date: 20210425
    /// </summary>
    public class Solution155
    {
        public class MinStack {

            private Stack<int> stack;
            private Stack<int> mins;

            /** initialize your data structure here. */
            public MinStack() {
                stack = new Stack<int>();
                mins = new Stack<int>();
            }
            
            public void Push(int val) {
                stack.Push(val);
                if(!mins.TryPeek(out int min) || min >= val){
                    mins.Push(val);
                }else{
                    mins.Push(min);
                }
            }
            
            public void Pop() {
                stack.Pop();
                mins.Pop();
            }
            
            public int Top() {
                return stack.Peek();
            }
            
            public int GetMin() {
                return mins.Peek();
            }
        }
    }
}
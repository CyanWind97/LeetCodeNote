using System.Collections;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 232
    /// title: 用栈实现队列
    /// problems: https://leetcode-cn.com/problems/implement-queue-using-stacks/
    /// date: 20210305
    /// </summary>
    public static class  Solution232
    {
       public class MyQueue {

            private Stack<int> stack1;
            private Stack<int> stack2;
             
            /** Initialize your data structure here. */
            public MyQueue() {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }
            
            /** Push element x to the back of queue. */
            public void Push(int x) {
                while(stack2.Count > 0){
                    stack1.Push(stack2.Pop());
                }

                stack1.Push(x);

            }
            
            /** Removes the element from in front of queue and returns that element. */
            public int Pop() {
                while(stack1.Count > 0){
                    stack2.Push(stack1.Pop());
                }
                
                return stack2.Pop();
            }
            
            /** Get the front element. */
            public int Peek() {
                while(stack1.Count > 0){
                    stack2.Push(stack1.Pop());
                }
                
                return stack2.Peek();
            }
            
            /** Returns whether the queue is empty. */
            public bool Empty() {
                return (stack1.Count == 0 && stack2.Count == 0);
            }
        } 
    }
}
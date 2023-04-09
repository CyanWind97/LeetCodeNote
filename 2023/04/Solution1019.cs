using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1019
    /// title: 链表中的下一个更大节点
    /// problems: https://leetcode.cn/problems/next-greater-node-in-linked-list/
    /// date: 20230410
    /// </summary>
    public static class Solution1019
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static int[] NextLargerNodes(ListNode head) {
            var result = new List<int>();
            var stack = new Stack<int>();

            int index = 0;
            while(head != null){
                while(stack.Count > 0 && result[stack.Peek()] < head.val){
                    result[stack.Pop()] = head.val;
                }

                result.Add(head.val);
                stack.Push(index);
                index++;
                head = head.next;
            }

            while(stack.Count > 0){
                result[stack.Pop()] = 0;
            }

            return result.ToArray();
        }
    }
}
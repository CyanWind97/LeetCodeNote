using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2487
    /// title: 从链表中移除节点
    /// problems: https://leetcode.cn/problems/remove-nodes-from-linked-list/description/?envType=daily-question&envId=2024-01-03
    /// date: 20240103
    /// </summary>
    public static class Solution2487
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RemoveNodes(ListNode head) {
            var stack = new Stack<ListNode>();
            var cur = head;
            while(cur != null){
                while(stack.Count > 0 && stack.Peek().val < cur.val){
                    stack.Pop();
                }

                stack.Push(cur);
                cur = cur.next;
            }

            var result = stack.Pop();

            while(stack.Count > 0){
                var next = result;
                result = stack.Pop();
                result.next = next;
            }

            return result;
        }
    }
}
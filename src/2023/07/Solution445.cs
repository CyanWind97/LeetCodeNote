using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 445
    /// title: 两数相加 II
    /// problems: https://leetcode.cn/problems/add-two-numbers-ii/
    /// date: 20230703
    /// </summary>
    public static class Solution445
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();

            while(l1 != null){
                stack1.Push(l1.val);
                l1 = l1.next;
            }

            while(l2 != null){
                stack2.Push(l2.val);
                l2 = l2.next;
            }

            ListNode head = null;
            int carry = 0;
            while(stack1.Count > 0 || stack2.Count > 0 || carry != 0){
                int sum = carry + (stack1.Count > 0 ? stack1.Pop() : 0) + (stack2.Count > 0 ? stack2.Pop() : 0);
                carry = sum / 10;
                var node = new ListNode(sum % 10);
                node.next = head;
                head = node;
            }

            return head;
        }
    }
}
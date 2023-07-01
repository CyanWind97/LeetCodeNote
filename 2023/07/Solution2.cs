using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2
    /// title: 两数相加
    /// problems: https://leetcode.cn/problems/add-two-numbers/
    /// date: 20230702
    /// </summary>
    public static class Solution2
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
            var head = new ListNode();
            int carry  = 0;
            var node = head;
            while(l1 != null || l2 != null || carry  != 0){
                int sum = carry + (l1?.val ?? 0) + (l2?.val ?? 0);
                carry = sum / 10;
                node.next = new ListNode(sum % 10);
                node = node.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            return head.next;
        }
    }
}
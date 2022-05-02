using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 206
    /// title:  反转链表
    /// problems: https://leetcode-cn.com/problems/reverse-linked-list/
    /// date: 20220502
    /// priority: 0002
    /// time: 00:09:24.91
    /// </summary>
    public static class CodeTop206
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode ReverseList(ListNode head) 
        {
            if(head?.next == null)
                return head;
            
            ListNode pre = null;
            ListNode cur = head;

            while(cur != null){
                var next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            
            return cur;
        }

        // 递归法
        public static ListNode ReverseList_1(ListNode head)
        {
            if(head?.next == null)
                return head;
            
            var newHead = ReverseList_1(head.next);
            head.next.next = head;
            head.next = null;

            return newHead;
        }
    }
}
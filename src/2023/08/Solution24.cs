using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 24
    /// title: 两两交换链表中的节点
    /// problems: https://leetcode.cn/problems/swap-nodes-in-pairs/
    /// date: 20230806
    /// </summary>
    public static class Solution24
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode SwapPairs(ListNode head) {
            var dump = new ListNode();
            dump.next = head;

            var pre = dump;
            var cur = dump.next;

            while(cur?.next != null){
                var tmp = cur.next;
                cur.next = tmp.next;
                tmp.next = cur;
                pre.next = tmp;
                
                pre = cur;
                cur = cur.next;
            }

            return dump.next;
        }   
    }
}
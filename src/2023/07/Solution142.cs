using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 141
    /// title: 环形链表
    /// problems: https://leetcode.cn/problems/linked-list-cycle/
    /// date: 20230730
    /// </summary>
    public static class Solution142
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) {
                val = x;
                next = null;
            }
        }

        public static ListNode DetectCycle(ListNode head) {
            var slow = head;
            var fast = slow?.next?.next;

            while(fast != null){
                slow = slow.next;

                if(slow == fast){
                    var node = head;
                    while(slow != node){
                        slow = slow.next;
                        node = node.next;
                    }

                    return node;
                }

                fast = fast?.next?.next;
            }

            
            return null;
        }
    }
}
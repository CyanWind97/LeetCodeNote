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
    /// date: 20230729
    /// </summary>
    public static class Solution141
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) {
                val = x;
                next = null;
            }
        }

        public static bool HasCycle(ListNode head) {
            var slow = head;
            var fast = slow?.next?.next;
            
            while(fast != null){
                slow =slow.next;
                if(fast == slow)
                    return true;
                
                fast = fast.next?.next;
            }

            return false; 
        }
    }
}
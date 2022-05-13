using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 142
    /// title:  环形链表 II
    /// problems: https://leetcode.cn/problems/linked-list-cycle-ii/
    /// date: 20220512
    /// priority: 0038
    /// time: 00:11:00.85
    /// </summary>
    public class CodeTop142
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
            var visited = new HashSet<ListNode>();

            while(head != null){
                if(!visited.Add(head))
                    return head;
                
                head = head.next;
            }
            
            return null;
        }

        // O(1)空间
        public static ListNode DetectCycle_1(ListNode head) {
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
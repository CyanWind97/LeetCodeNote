using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 141
    /// title:  环形链表
    /// problems: https://leetcode.cn/problems/linked-list-cycle/
    /// date: 20220510
    /// priority: 0028
    /// time: 00:04:14.80
    /// </summary>
    public class CodeTop141
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
            var visited = new HashSet<ListNode>();

            while(head != null){
                if(!visited.Add(head))
                    return true;
                
                head = head.next;
            }
            
            return false;
        }

        public static bool HasCycle_1(ListNode head){
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
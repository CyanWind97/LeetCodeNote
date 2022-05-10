using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 25
    /// title:  K 个一组翻转链表
    /// problems: https://leetcode.cn/problems/reverse-nodes-in-k-group/
    /// date: 20220510
    /// priority: 0029
    /// time: 00:18:02.72
    public static class CodeTop25
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode ReverseKGroup(ListNode head, int k) {
            var fast = head;
            var prev = head;
            var flag = false;

            while(fast != null){
                var slow = fast;
                
                int count = 0;
                while(count < k && fast != null){
                    fast = fast.next;
                    count++;
                }

                if(count != k){
                    prev.next = slow;
                    prev = fast;
                    break;
                }
                
                var stack = new Stack<ListNode>();
                while(slow != fast){
                    stack.Push(slow);
                    slow = slow.next;
                }

                var cur = (prev.next = stack.Pop());
                if(!flag){
                    head = cur;
                    flag = true;
                }
                
                while(stack.Count > 0){
                    cur.next = stack.Pop();
                    cur = cur.next;
                }

                prev = cur;
            }

            if(prev != null)
                prev.next = null;

            return head;
        }

        // O(1) 额外空间
        public static ListNode ReverseKGroup_1(ListNode head, int k) {
            var hair = new ListNode();
            hair.next = head;
            var prev = hair;

            while(head != null){
                var tail = prev;
                for(int i = 0; i < k; i++){
                    tail = tail.next;
                    if(tail == null)
                        return hair.next;
                }

                var next = tail.next;

                var node = tail.next;
                var h = head;
                while(node != tail){
                    var n = h.next;
                    h.next = node;
                    node = h;
                    h = n;
                }

                (head, tail) = (tail, head);

                prev.next = head;
                tail.next = next;
                prev = tail;
                head = tail.next;
            }

            return hair.next;
        }
    }
}
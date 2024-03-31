using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 148
    /// title:  排序链表
    /// problems: https://leetcode.cn/problems/sort-list/
    /// date: 20220515
    /// priority: 0057
    /// time: 00:45:32.95 timeout
    /// </summary>
    public static class CodeTop148
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode SortList(ListNode head) {
            
            ListNode Sort(ListNode start, ListNode end){
                if(start == end){
                    if(start != null)
                        start.next = null;
                    
                    return start;
                }
                
                var slow = start;
                var fast =  slow?.next;

                while(fast != end){
                    fast = fast?.next;
                    if(fast != end){
                        fast = fast?.next;
                        slow = slow?.next;
                    }
                }

                var mid = slow;
                var next = mid.next;
                var left = Sort(start, mid);
                var right = Sort(next, end);
                
                return Merge(left, right);
            }

            ListNode Merge(ListNode left, ListNode right){
                var newStart = new ListNode();
                var cur = newStart;
                while(left != null && right != null){
                    if(left.val > right.val){
                        cur.next = right;
                        right = right.next;
                    }else{
                        cur.next = left;
                        left = left.next;
                    }

                    cur = cur.next;
                }

                if(left == null)
                    cur.next = right;
                else
                    cur.next = left;


                return newStart.next;
            }

            return  Sort(head, null);
        }

        public static ListNode SortList_1(ListNode head){
            if(head == null)
                return null;
            
            var heap = new PriorityQueue<ListNode, int>();
            while(head != null){
                heap.Enqueue(head, head.val);
                head = head.next;
            }

            var newHead = new ListNode();
            var cur = newHead;
            
            while(heap.Count > 0){
                cur.next = heap.Dequeue();
                cur = cur.next;
            }

            cur.next = null;

            return newHead.next;
        }
    }
}
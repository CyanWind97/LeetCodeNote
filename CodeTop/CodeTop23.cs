using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 23
    /// title:  合并K个升序链表
    /// problems: https://leetcode.cn/problems/merge-k-sorted-lists/
    /// date: 20220516
    /// priority: 0064
    /// time: 00:15:00.00
    /// </summary>  
    public static class CodeTop23
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        
        public static ListNode MergeKLists(ListNode[] lists) {
            var heap = new PriorityQueue<ListNode, int>();
            var dump = new ListNode();
            var cur = dump;

            int length = lists.Length;
            for(int i = 0; i < length; i++){
                if(lists[i] == null)
                    continue;

                heap.Enqueue(lists[i], lists[i].val);
            }

            while(heap.Count > 0){
                var node = heap.Dequeue();
                cur.next = node;
                cur = cur.next;

                node = node.next;
                if(node != null){
                    heap.Enqueue(node, node.val);
                }
            }

            return dump.next;
        }
    }
}
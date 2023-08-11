using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 23
    /// title: 合并 K 个升序链表
    /// problems: https://leetcode.cn/problems/merge-k-sorted-lists/
    /// date: 20230812
    /// </summary>
    public static class Solution23
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
            var heap = new PriorityQueue<(ListNode Node, int ListIndex), int>();
            var dump = new ListNode();
            var cur = dump;

            int length = lists.Length;
            for(int i = 0; i < length; i++){
                if(lists[i] == null)
                    continue;

                heap.Enqueue((lists[i], i), lists[i].val);
                lists[i] = lists[i].next;
            }

            while(heap.Count > 0){
                (var node, var index) = heap.Dequeue();
                cur.next = node;
                cur = cur.next;

                if(lists[index] != null){
                    heap.Enqueue((lists[index], index), lists[index].val);
                    lists[index] = lists[index].next;
                }
            }

            return dump.next;
        }
    }
}
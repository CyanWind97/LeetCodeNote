using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 21
    /// title: 合并两个有序链表
    /// problems: https://leetcode.cn/problems/merge-two-sorted-lists/
    /// date: 20230805
    /// </summary>
    public static class Solution21
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            var head = new ListNode();
            var cur = head;
            
            while(list1 != null && list2 != null){
                if(list1.val < list2.val){
                    cur.next = list1;
                    list1 = list1.next;
                }else{
                    cur.next = list2;
                    list2 = list2.next;
                }

                cur = cur.next;
            }

            cur.next = list1 ?? list2;

            return head.next;
        }
    }
}
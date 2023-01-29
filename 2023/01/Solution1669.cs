using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1669
    /// title: 合并两个链表
    /// problems: https://leetcode.cn/problems/merge-in-between-linked-lists/
    /// date: 20230130
    /// </summary>
    public static class Solution1669
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
            int index = 0;
            var curr = list1;
            while(index < a - 1){
                curr = curr.next;
                index++;
            }

            var prev = curr;
            while(index <= b){
                curr = curr.next;
                index++;
            }

            prev.next = list2;
            while(prev.next != null){
                prev = prev.next;
            }

            prev.next = curr;

            return list1;
        }
    }
}
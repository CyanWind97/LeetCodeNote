using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2181
/// title:  合并零之间的节点
/// problems: https://leetcode.cn/problems/merge-nodes-in-between-zeros
/// date: 20240909
/// </summary>
public static class Solution2181
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

    public static ListNode MergeNodes(ListNode head) {
        var newHead = new ListNode();
        var node = newHead;
        var curr = head.next;
        var sum = 0;

        while(curr != null){
            if(curr.val == 0){
                node.next = new ListNode(sum);
                node = node.next;
                sum = 0;
            }else{
                sum += curr.val;
            }

            curr = curr.next;
        }

        return newHead.next;
    }
}

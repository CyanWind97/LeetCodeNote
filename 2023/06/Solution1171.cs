using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote 
{
    /// <summary>
    /// no: 1171
    /// title: 比较字符串最从链表中删去总和值为零的连续节点小字母出现频次
    /// problems: https://leetcode.cn/problems/remove-zero-sum-consecutive-nodes-from-linked-list/
    /// date: 20230611
    /// </summary>
    public static class Solution1171 {

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RemoveZeroSumSublists(ListNode head) {
            var dummy = new ListNode(0);
            dummy.next = head;
            var dic = new Dictionary<int, ListNode>();
            int sum = 0;
            dic[0] = dummy;

            for (var node = dummy; node != null; node = node.next) {
                sum += node.val;
                dic[sum] = node;
            }

            sum = 0;
            for (var node = dummy; node != null; node = node.next) {
                sum += node.val;
                node.next = dic[sum].next;
            }
            
            return dummy.next;
        }
    }
}
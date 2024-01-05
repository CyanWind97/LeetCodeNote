using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2807
    /// title: 在链表中插入最大公约数
    /// problems: https://leetcode.cn/problems/insert-greatest-common-divisors-in-linked-list/description/?envType=daily-question&envId=2024-01-06
    /// date: 20240106
    /// </summary>
    public static class Solution2807
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode InsertGreatestCommonDivisors(ListNode head) {
            int gcd(int a, int b) => b == 0 ? a : gcd(b, a % b);
            var node = head;
            
            while(node?.next != null){
                var next = node.next;
                var num = gcd(node.val, next.val);

                var newNode = new ListNode(num, next);
                node.next = newNode;
                node = next;
            }

            return head;
        }
    }
}
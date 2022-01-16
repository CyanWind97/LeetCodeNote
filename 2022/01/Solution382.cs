using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 382
    /// title: 链表随机节点
    /// problems: https://leetcode-cn.com/problems/linked-list-random-node/
    /// date: 20220116
    /// </summary>
    public static class Solution382
    {
          public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution {
            IList<int> _list;
            Random _random;
            public Solution(ListNode head) {

                _list = new List<int>();
                while (head != null) {
                    _list.Add(head.val);
                    head = head.next;
                }
                _random = new Random();

            }
            
            public int GetRandom() {
                return _list[_random.Next(_list.Count)];
            }
        }
    }
}
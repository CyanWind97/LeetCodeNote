using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 160
    /// title: 相交链表
    /// problems: https://leetcode-cn.com/problems/intersection-of-two-linked-lists/
    /// date: 20210604
    /// </summary>
    public static class Solution160
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode temp = headA;
            while (temp != null) {
                set.Add(temp);
                temp = temp.next;
            }

            temp = headB;
            while (temp != null) {
                if (set.Contains(temp)) {
                    return temp;
                }
                temp = temp.next;
            }

            return null;
        }
        

        // 参考解答
        // 若有相交，假设相交部分有c个节点， a + c = m, b + c = n
        // pa移动a + c + b，pb移动b + c + a次后，有公共节点
        public static ListNode GetIntersectionNode_1(ListNode headA, ListNode headB) {
            if(headA == null || headB == null)
                return null;
            
            ListNode pA = headA;
            ListNode pB = headB;
            while(pA != pB){
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }

            return pA;
        }
    }
}
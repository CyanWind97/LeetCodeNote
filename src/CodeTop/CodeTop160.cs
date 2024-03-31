namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 160
    /// title:  相交链表
    /// problems: https://leetcode.cn/problems/intersection-of-two-linked-lists/
    /// date: 20220517
    /// priority: 0076
    /// time: 00:10:31.28
    /// </summary>
    public static class CodeTop160
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            var curA = headA;
            var curB = headB;
            
            while(curA != curB){
                curA = curA == null ? headB : curA.next;
                curB = curB == null ? headA : curB.next;
            }

            return curA;
        }
    }
}
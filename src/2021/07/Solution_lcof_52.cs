namespace LeetCodeNote
{
    /// <summary>
    /// no: 52
    /// title: 两个链表的第一个公共节点
    /// problems: https://leetcode-cn.com/problems/liang-ge-lian-biao-de-di-yi-ge-gong-gong-jie-dian-lcof/
    /// date: 20210721
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_52
    {
         public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            if(headA == null || headB == null)
                return null;

            ListNode curA = headA;
            ListNode curB = headB;
            while(curA != curB){
                curA = curA == null ? headB : curA.next;
                curB = curB == null ? headA : curB.next;
            }
            
            return curA;
        }
    }
}
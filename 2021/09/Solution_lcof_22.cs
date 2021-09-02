namespace LeetCodeNote
{
    /// <summary>
    /// no: 22
    /// title: 链表中倒数第k个节点
    /// problems: https://leetcode-cn.com/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof/
    /// date: 20210902
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_22
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode GetKthFromEnd(ListNode head, int k) {
            ListNode right = head;
            for(int i = 1; i < k; i++){
                right = right.next;
            }

            ListNode left = head;

            while(right.next != null){
                right = right.next;
                left = left.next;
            }

            return left;
        }   
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 237
    /// title:  删除链表中的节点
    /// problems: https://leetcode-cn.com/problems/delete-node-in-a-linked-list/
    /// date: 20211102
    /// </summary>
    public static class Solution237
    {

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public static void DeleteNode(ListNode node) {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        
    }
}
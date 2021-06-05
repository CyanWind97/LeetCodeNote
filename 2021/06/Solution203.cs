namespace LeetCodeNote
{
    /// <summary>
    /// no: 203
    /// title: 移除链表元素
    /// problems: https://leetcode-cn.com/problems/remove-linked-list-elements/
    /// date: 20210605
    /// </summary>
    public static class Solution203
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RemoveElements(ListNode head, int val) {
            ListNode newHead = new ListNode();
            ListNode pre = newHead;

            while(head != null){
                if(head.val != val){
                    pre.next = head;
                    pre = head;
                }

                head = head.next;
            }

            return newHead.next;
        }
    }
}
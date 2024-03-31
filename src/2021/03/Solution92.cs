namespace LeetCodeNote
{
    /// <summary>
    /// no: 92
    /// title: 反转链表 II
    /// problems: https://leetcode-cn.com/problems/reverse-linked-list-ii/
    /// date: 20210318
    /// </summary>
    public static class Solution92
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode ReverseBetween(ListNode head, int left, int right) {
            int count = 1;
            var cur = head;
            ListNode pre = null;
            while(count < left){
                pre = cur;
                cur = cur.next;
                count++;
            }

            var last = cur;
            ListNode next = null;

            while(count <= right){
                var tmp = cur.next;

                if(next != null){
                    cur.next = next;
                }
                
                next = cur;
                cur = tmp;
                count++;
            }

            if(pre != null){
                pre.next = next;
            }else{
                head = next;
            }

            last.next = cur;

            return head;
        }
    }
}
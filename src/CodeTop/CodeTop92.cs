namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 92
    /// title:  反转链表 II
    /// problems: https://leetcode.cn/problems/reverse-linked-list-ii/
    /// date: 20220516
    /// priority: 0067
    /// time: 00:20:06.01
    /// </summary>  
    public static class CodeTop92
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
            var dump = new ListNode();
            dump.next = head;
            var pre = dump;
            
            for(int i = 1; i < left; i++){
                pre = pre.next;
            }
            
            var cur = pre.next;
            ListNode next = null;

            for(int i = left; i <= right; i++){
                next = cur.next;
                cur.next = next.next;
                next.next = pre.next;
                pre.next = next;
            }

            return dump.next;
        }
    }
}
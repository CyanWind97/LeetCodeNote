namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 143
    /// title:  重排链表
    /// problems: https://leetcode.cn/problems/reorder-list/
    /// date: 20220519
    /// priority: 0087
    /// time: 00:45:04.71 timeout
    /// </summary>
    public static class CodeTop143
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static void ReorderList(ListNode head) {
            var slow = head;
            var fast = head.next;

            while(fast?.next != null){
                slow = slow.next;
                fast = fast?.next?.next;
            }

            ListNode prev = null;
            var cur = slow.next;

            while(cur != null){
                var next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            cur = prev;
            slow.next = null;

            while(head != null && cur != null){
                var tmp1 = head.next;
                var tmp2 = cur.next;
                
                head.next = cur;
                head = tmp1;

                cur.next = head;
                cur = tmp2;
            }

        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 61
    /// title: 旋转链表
    /// problems: https://leetcode-cn.com/problems/rotate-list/
    /// date: 20210327
    /// </summary>
    public static class Solution61
    {
          public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RotateRight(ListNode head, int k) {
            if(head == null)
                return null;

            var cur = head;
            int count = 1;
            while(cur.next != null){
                count++;
                cur = cur.next;
            }

            k = count - (k % count);
            cur.next = head;
            for(int i = 0; i < k; i++){
                cur = cur.next;
            }

            head = cur.next;
            cur.next = null;

            return head;
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 83
    /// title: 删除排序链表中的重复元素
    /// problems: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/
    /// date: 20210326
    /// </summary>
    public static class Solution83
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode DeleteDuplicates(ListNode head) {
            if(head == null)
                return head;
            
            ListNode cur = head;
            while(cur.next != null){
                if(cur.val == cur.next.val){
                    cur.next = cur.next.next;
                }else{
                    cur = cur.next;
                }
            }

            return head;
        }
    }
}
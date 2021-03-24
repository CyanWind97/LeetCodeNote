namespace LeetCodeNote
{
    /// <summary>
    /// no: 82
    /// title: 删除排序链表中的重复元素 II
    /// problems: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/
    /// date: 20210325
    /// </summary>
    public static class Solution82
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
            
            ListNode dummy = new ListNode(0, head);
            ListNode cur = dummy;
            while(cur.next != null && cur.next.next != null){
                if(cur.next.val == cur.next.next.val){
                    int x = cur.next.val;
                    while(cur.next != null && cur.next.val == x){
                        cur.next = cur.next.next;
                    }
                }else{
                    cur = cur.next;
                }
            }

            return dummy.next;
        }
    }
}
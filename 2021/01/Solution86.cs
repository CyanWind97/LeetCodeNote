namespace LeetCodeNote
{
    /// <summary>
    /// no: 86
    /// title: 分隔链表
    /// problems: https://leetcode-cn.com/problems/partition-list/
    /// date: 20210103
    /// </summary>
    public static class Solution86
    {
       
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        
        public static ListNode Partition(ListNode head, int x) {
            ListNode cur = head;
            ListNode left = null;
            ListNode leftHead = null;
            ListNode right = null;
            ListNode rightHead = null;
            while(cur != null){
                ListNode next = cur.next;
                if(cur.val < x){
                    if(left == null){
                        left = cur;
                        leftHead = cur;
                    }else{
                        left.next = cur;
                        left = left.next;
                    }
                    left.next = null;
                }else{
                    if(right == null){
                        right = cur;
                        rightHead = cur;
                    }else{
                        right.next = cur;
                        right = right.next;
                    }
                    right.next = null;
                }

                cur = next;
            }

            if(leftHead != null)
                left.next = rightHead;
            else
                leftHead = rightHead;

            return leftHead;
        }

        public static ListNode Partition_1(ListNode head, int x) {
            ListNode cur = head;
            if(head == null)
                return null;

            ListNode left = null;
            ListNode leftEnd = null;
            ListNode right = null;
            ListNode rightEnd = null;

            if(cur.val < x)
                left = head;
            else
                right = head;

            while(cur != null){
                if(left != null){
                    ListNode tmp = null;
                    if(leftEnd != null){
                        tmp = leftEnd.next;
                        leftEnd.next = left;
                    }else{
                        head = left;
                        tmp = right;
                    }

                    while(cur != null && cur.val < x){
                        leftEnd = cur;
                        cur = cur.next;
                    }
                    left = null;
                    leftEnd.next = tmp == null ? cur : tmp;
                    right = cur;
                }else{
                    if(rightEnd != null)
                        rightEnd.next = right;

                    while(cur != null && cur.val >= x){
                        rightEnd = cur;
                        cur = cur.next;
                    }
                    left = cur;
                }
            }

            if(rightEnd != null)
                rightEnd.next = null;

            return head;
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 725
    /// title: 分隔链表
    /// problems: https://leetcode-cn.com/problems/split-linked-list-in-parts/
    /// date: 20210922
    /// </summary>
    public static class Solution725
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }
        
        public static ListNode[] SplitListToParts(ListNode head, int k) {
            var result = new ListNode[k];

            int count = 0;
            result[0] = head;
            while(head != null){
                count++;
                head = head.next;
            }

            head = result[0];
            int size =  count / k;
            int remainder =  count % k;
            for(int i = 1; i < k && head != null; i++){
                ListNode pre = null;
                for(int j = 0; j < size - 1; j++){
                    head = head.next;
                }

                if(size > 0){
                    pre = head;
                    head = head.next;
                }

                if(remainder > 0){
                    pre = head;
                    head = head.next;
                    remainder--;
                }

                pre.next = null;
                result[i] = head;
            }


            return result;
        }
    }
}
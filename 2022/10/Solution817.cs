using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 817
    /// title: 链表组件
    /// problems: https://leetcode.cn/problems/linked-list-components/
    /// date: 20221012
    /// </summary>
    public static class Solution817
    {
          public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static int NumComponents(ListNode head, int[] nums) {
            var set = nums.ToHashSet();
            int components = 0;
            bool flag = false;

            for(var node = head; node != null; node = node.next){
                if(set.Contains(node.val)){
                    if(!flag)
                        flag = true;
                }else if(flag){
                    components++;
                    flag = false;
                }
            }

            if(flag)
                components++;
            
            return components;
        }
    }
}
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 109
    /// title:  有序链表转换二叉搜索树
    /// problems: https://leetcode.cn/problems/convert-sorted-list-to-binary-search-tree/
    /// date: 20220519
    /// priority: 0088
    /// time: 00:13:56.12
    /// </summary>
    public static class CodeTop109
    {
        
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }
        
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static TreeNode SortedListToBST(ListNode head) {
            var values = new List<int>();
            while(head != null){
                values.Add(head.val);
                head = head.next;
            }

            TreeNode GetTreeNode(int left, int right){
                if(left == right)
                    return new TreeNode(values[left]);
                
                if(left > right)
                    return null;
                
                int mid = (right + left + 1) / 2;
                var node = new TreeNode(values[mid]);

                node.left = GetTreeNode(left, mid - 1);
                node.right = GetTreeNode(mid + 1, right);

                return node;
            }

            return GetTreeNode(0, values.Count - 1);
        }

        // 参考解答 分治 中序遍历优化
        public static TreeNode SortedListToBST_1(ListNode head) {
            var cur = head;
            int count = 0;
            while(cur != null){
                cur = cur.next;
                count++;
            }

            TreeNode GetTreeNode(int left, int right){
                if(left > right)
                    return null;
                
                int mid = (right + left + 1) / 2;
                // 先空置
                var node = new TreeNode();
                node.left = GetTreeNode(left, mid - 1);
                node.val = head.val;
                head = head.next;
                node.right = GetTreeNode(mid + 1, right);

                return node;
            }

            return GetTreeNode(0, count - 1);
        }
    }
}
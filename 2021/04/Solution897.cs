namespace LeetCodeNote
{
    /// <summary>
    /// no: 897
    /// title: 递增顺序搜索树
    /// problems: https://leetcode-cn.com/problems/increasing-order-search-tree/
    /// date: 20210425
    /// </summary>
    public static class Solution897
    {
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

        public static TreeNode IncreasingBST(TreeNode root) {
            TreeNode head = new TreeNode(-1);
            TreeNode pre = head;
            
            void Change(TreeNode node)
            {
                if(node.left != null)
                    Change(node.left);
                
                pre.right = node;
                node.left = null;
                pre = node;

                if(node.right != null)
                    Change(node.right);
            }

            Change(root);

            return head.right;
        }
    }
}
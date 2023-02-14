namespace LeetCodeNote
{
    ///<summary>
    /// no: 669
    /// title: 修剪二叉搜索树
    /// problems: https://leetcode.cn/problems/trim-a-binary-search-tree/
    /// date: 20220910
    /// </summary>
    public static class Solution669
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


        public static TreeNode TrimBST(TreeNode root, int low, int high) {
            while (root != null && (root.val < low || root.val > high)) {
                    root = root.val < low ? root.right : root = root.left;
            }

            if (root == null) 
                return null;
            
            for (var node = root; node.left != null; ) {
                if (node.left.val < low)
                    node.left = node.left.right;
                else
                    node = node.left;
            }
            for (var node = root; node.right != null; ) {
                if (node.right.val > high)
                    node.right = node.right.left;
                else
                    node = node.right;
            }

            return root;
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 814
    /// title: 二叉树剪枝
    /// problems: https://leetcode.cn/problems/binary-tree-pruning/
    /// date: 20220721
    /// </summary>
    public static class Solution814
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

        public static TreeNode PruneTree(TreeNode root) {

            TreeNode GetNode(TreeNode node){
                if(node == null)
                    return null;
                
                node.left = GetNode(node.left);
                node.right = GetNode(node.right);

                return node.val == 0 && node.left == null && node.right == null
                    ? null
                    : node; 
            }

            return GetNode(root);
        }
    }
}
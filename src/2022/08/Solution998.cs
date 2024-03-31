namespace LeetCodeNote
{
    /// <summary>
    /// no: 998
    /// title: 最大二叉树 II
    /// problems: https://leetcode.cn/problems/maximum-binary-tree-ii/
    /// date: 20220830
    /// </summary>
    public static class Solution998
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

        public static TreeNode InsertIntoMaxTree(TreeNode root, int val) {
            if(root == null)
                return null;
            
            var node = new TreeNode(val);
            if(root.val < val){
                node.left = root;
                return node;
            }

            var cur = root;
            while(cur.right != null && val < cur.right.val){
                cur = cur.right;
            }

            if(cur.right == null){
                cur.right = node;
            }else{
                node.left = cur.right;
                cur.right = node;
            }

            return root;
        }
    }
}
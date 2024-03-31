namespace LeetCodeNote
{
    /// <summary>
    /// no: 700
    /// title:  二叉搜索树中的搜索
    /// problems: https://leetcode-cn.com/problems/search-in-a-binary-search-tree/
    /// date: 20211126
    /// </summary>
    public static class Solution700
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

        public static  TreeNode SearchBST(TreeNode root, int val) {
            var node = root;
            while(node != null){
                if (node.val > val)
                    node = node.left;
                else if (node.val < val)
                    node = node.right;
                else
                    break;
            }

            return node;
        }
    }
}
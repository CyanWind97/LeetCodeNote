namespace LeetCodeNote
{
    /// <summary>
    /// no: 938
    /// title: 二叉搜索树的范围和
    /// problems: https://leetcode.cn/problems/range-sum-of-bst/description
    /// date: 20210427
    /// </summary>
    public static partial class Solution938
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

        public static int RangeSumBST(TreeNode root, int low, int high) {
            if(root == null)
                return 0;
            
            if(root.val > high)
                return RangeSumBST(root.left, low, high);
            else if(root.val < low)
                return RangeSumBST(root.right, low, high);
            else
                return root.val + RangeSumBST(root.left, low, root.val) +  RangeSumBST(root.right, root.val, high);
        }

    }
}
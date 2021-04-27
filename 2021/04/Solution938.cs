namespace LeetCodeNote
{
    /// <summary>
    /// no: 938
    /// title: 递增顺序搜索树
    /// problems: https://leetcode-cn.com/problems/increasing-order-search-tree/
    /// date: 20210425
    /// </summary>
    public static class Solution938
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
namespace LeetCodeNote
{
    /// <summary>
    /// no: 654
    /// title:  最大二叉树
    /// problems: https://leetcode.cn/problems/maximum-binary-tree/
    /// date: 20220820
    /// </summary>
    public static class Solution654
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

        public static TreeNode ConstructMaximumBinaryTree(int[] nums) {
            int length = nums.Length;
            var root = new TreeNode(nums[0]);
            
            for(int i = 1; i < length; i++){
                var node = new TreeNode(nums[i]);
                if(node.val > root.val){
                    node.left = root;
                    root = node;
                }else{
                    var cur = root;
                    while(cur.right != null && cur.right.val > node.val){
                        cur = cur.right;
                    }
                    
                    node.left = cur.right;
                    cur.right = node;
                }
            }

            return root;
        }
    }
}
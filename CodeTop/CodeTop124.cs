using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 124
    /// title:  二叉树中的最大路径和
    /// problems: https://leetcode-cn.com/problems/binary-tree-maximum-path-sum/
    /// date: 20220503
    /// priority: 0004
    /// time: 00:20:59
    /// </summary>
    public static  class CodeTop124
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

        public static int MaxPathSum(TreeNode root) 
        {
            var result = -1001;

            int Sum(TreeNode node)
            {
                int sum = node.val;
                int leftSum = node.left != null
                             ? Math.Max(0, Sum(node.left))
                             : 0;
                int rightSum = node.right != null
                             ? Math.Max(0, Sum(node.right))
                             : 0;
                sum += leftSum;
                sum += rightSum;
                
                result = Math.Max(sum, result);

                return sum - Math.Min(leftSum, rightSum);
            }

            Sum(root);

            return result;
        }
    }
}
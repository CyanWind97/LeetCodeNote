using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 543
    /// title:  二叉树的直径
    /// problems: https://leetcode.cn/problems/diameter-of-binary-tree/
    /// date: 20220512
    /// priority: 0036
    /// time: 00:04:06.94
    /// </summary>
    public static class CodeTop543
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

        public static int DiameterOfBinaryTree(TreeNode root) {
            int max = 0;

            int GetDiameter(TreeNode node){
                if(node == null)
                    return 0;

                var left = GetDiameter(node.left);
                var right = GetDiameter(node.right);

                max = Math.Max(max, left + right);

                return Math.Max(left, right) + 1;
            }

            GetDiameter(root);

            return max;
        }
    }
}
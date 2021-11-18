using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 563
    /// title: 二叉树的坡度
    /// problems: https://leetcode-cn.com/problems/binary-tree-tilt/
    /// date: 20211118
    /// </summary>
    public static class Solution563
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

        public static int FindTilt(TreeNode root) {
            int result = 0;
            
            int GetSum(TreeNode node){
                if (node == null)
                    return 0;

                int left = GetSum(node.left);
                int right = GetSum(node.right);

                result += Math.Abs(right - left);
                
                return left + right + node.val;
            }

            GetSum(root);

            return result;
        }
    }
}
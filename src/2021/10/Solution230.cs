using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 230
    /// title: 二叉搜索树中第K小的元素
    /// problems: https://leetcode-cn.com/problems/kth-smallest-element-in-a-bst/
    /// date: 20211017
    /// </summary>

    public static class Solution230
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

        public static int KthSmallest(TreeNode root, int k) {
            var stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0) {
                while (root != null) {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                --k;
                if (k == 0) {
                    break;
                }
                root = root.right;
            }
            return root.val;
        }
    }
}
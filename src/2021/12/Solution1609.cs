using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1609
    /// title:  奇偶树
    /// problems: https://leetcode-cn.com/problems/even-odd-tree/
    /// date: 20211225
    /// </summary>
    public static class Solution1609
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


        public static bool IsEvenOddTree(TreeNode root) {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0) {
                int size = queue.Count;
                int prev = level % 2 == 0 ? int.MinValue : int.MaxValue;
                for (int i = 0; i < size; i++) {
                    TreeNode node = queue.Dequeue();
                    int value = node.val;
                    if (level % 2 == value % 2) {
                        return false;
                    }
                    if ((level % 2 == 0 && value <= prev) || (level % 2 == 1 && value >= prev)) {
                        return false;
                    }
                    prev = value;
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                level++;
            }
            return true;
        }
    }
}
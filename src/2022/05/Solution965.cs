using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 965
    /// title: 单值二叉树
    /// problems: https://leetcode.cn/problems/univalued-binary-tree/
    /// date: 20220524
    /// </summary>
    public static class Solution965
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

        public static bool IsUnivalTree(TreeNode root) {
            var uniVal = root.val;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0){
                var node = queue.Dequeue();
                if(node.val != uniVal)
                    return false;
                
                if(node.left != null)
                    queue.Enqueue(node.left);
                
                if(node.right != null)
                    queue.Enqueue(node.right);
            }

            return true;
        }
    }
}
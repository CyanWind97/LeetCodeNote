using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 617
    /// title: 合并二叉树
    /// problems: https://leetcode.cn/problems/merge-two-binary-trees/
    /// date: 20230814
    /// </summary>
    public static class Solution617
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

        public static TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
            if (root1 == null && root2 == null)
                return null;

            var queue = new Queue<(TreeNode Cur, TreeNode Node1, TreeNode Node2)>();
            var root = new TreeNode();
            queue.Enqueue((root, root1, root2));

            while(queue.Count > 0){
                var (cur, node1, node2) = queue.Dequeue();
        
                cur.val = (node1?.val ?? 0) + (node2?.val ?? 0);
                if (node1?.left is not null || node2?.left is not null){
                    cur.left = new TreeNode();
                    queue.Enqueue((cur.left, node1?.left, node2?.left));
                }

                if (node1?.right is not null || node2?.right is not null){
                    cur.right = new TreeNode();
                    queue.Enqueue((cur.right, node1?.right, node2?.right));
                }
            }

            return root;
        }
    }
}
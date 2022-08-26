using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 662
    /// title: 二叉树最大宽度
    /// problems: https://leetcode.cn/problems/maximum-width-of-binary-tree/
    /// date: 20220827
    /// </summary>
    public static class Solution662
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

        public static int WidthOfBinaryTree(TreeNode root) {
            var queue = new Queue<(TreeNode Node, int Order)>();
            int maxWidth = 1;
            
            queue.Enqueue((root, 0));
            while(queue.Count > 0){
                int count = queue.Count;
                (_, int first) = queue.Peek();

                while(count > 0){
                    (var node, int order) = queue.Dequeue();
                    if(node.left != null)
                        queue.Enqueue((node.left, order << 1));
                    
                    if(node.right != null)
                        queue.Enqueue((node.right, (order << 1) + 1));
                    
                    if(count == 1)
                        maxWidth = Math.Max(maxWidth, order - first + 1);

                    count--;
                }
            }

            return maxWidth;
        }
    }
}
using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 515
    /// title: 在每个树行中找最大值
    /// problems: https://leetcode.cn/problems/find-largest-value-in-each-tree-row/
    /// date: 20220624
    /// </summary>
    public static class Solution515
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

        public static IList<int> LargestValues(TreeNode root) {
            var result = new List<int>();
            
            void DFS(TreeNode node, int index){
                if(result.Count == index)
                    result.Add(node.val);
                else if(node.val > result[index])
                    result[index] = node.val;
                
                index++;
                if(node.left != null)
                    DFS(node.left, index);
                
                if(node.right != null)
                    DFS(node.right, index);
            }

            if(root != null)
                DFS(root, 0);
            
            return result;
        }

        // BFS
        public static IList<int> LargestValues_1(TreeNode root) {
            var res = new List<int>();
            
            if (root == null) 
                return new List<int>();
            
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                int count = queue.Count;
                int max = int.MinValue;
                while (count > 0) {
                    count--;
                    var node = queue.Dequeue();
                    max = Math.Max(max, node.val);
                    if (node.left != null) 
                        queue.Enqueue(node.left);
                    
                    if (node.right != null) 
                        queue.Enqueue(node.right);
                }

                res.Add(max);
            }
            return res;
        }
    }
}
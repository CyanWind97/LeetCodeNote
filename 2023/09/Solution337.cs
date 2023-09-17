using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 337
    /// title: 打家劫舍 III
    /// problems: https://leetcode.cn/problems/house-robber-iii/?envType=daily-question&envId=2023-09-18
    /// date: 20230918
    /// </summary>
    public class Solution337
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

        public static int Rob(TreeNode root) {
            var f = new Dictionary<TreeNode, int>();
            var g = new Dictionary<TreeNode, int>();
            var empty = new TreeNode(0);
            f[empty] = 0;
            g[empty] = 0;

            void DFS(TreeNode node) {
                if (node == empty)
                    return;

                var left = node.left ?? empty;
                var right = node.right ?? empty;
                
                DFS(left);
                DFS(right);
                
                f[node] = node.val + g[left] +  g[right];
                g[node] = Math.Max(f[left], g[left]) + Math.Max(f[right], g[right]);
            }

            DFS(root);

            return Math.Max(f[root], g[root]);
        }
    }
}
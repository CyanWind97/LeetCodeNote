using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 979
    /// title:  在二叉树中分配硬币
    /// problems: https://leetcode.cn/problems/distribute-coins-in-binary-tree/
    /// date: 20230714
    /// </summary>
    public static class Solution979
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

        public static int DistributeCoins(TreeNode root) {
            int result = 0;
            void Dfs(TreeNode node){
                if(node == null)
                    return;
                
                Dfs(node.left);
                Dfs(node.right);

                if(node.left != null && node.left.val != 1){
                    result += Math.Abs(node.left.val - 1);
                    node.val += node.left.val - 1;
                }

                if(node.right != null && node.right.val != 1){
                    result += Math.Abs(node.right.val - 1);
                    node.val += node.right.val - 1;
                }
            }

            Dfs(root);

            return result;
        }
    }
}
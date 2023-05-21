using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1080
    /// title: 根到叶路径上的不足节点
    /// problems: https://leetcode.cn/problems/insufficient-nodes-in-root-to-leaf-paths/
    /// date: 20230522
    /// </summary>
    public static class Solution1080
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

        public static TreeNode SufficientSubset(TreeNode root, int limit) {
            bool DFS(TreeNode node, int sum){
                sum += node.val;
                
                var left = node.left is not null 
                        ? DFS(node.left, sum)
                        : false;
                var right = node.right is not null 
                        ? DFS(node.right, sum)
                        : false;

                if(!left)
                    node.left = null;
                
                if(!right)
                    node.right = null;
                
                return left || right || sum >= limit;
            }

            return DFS(root, 0) ? root : null;
        }

        // 题解？
        // ？？
        // example: [1,2,-3,-5,null,4,null] -1 
        // [1,null,-3,4] ?
        public static TreeNode SufficientSubset_1(TreeNode root, int limit) {
            bool DFS(TreeNode node, int sum){
                if(node == null)
                    return false;
                
                sum += node.val;
                if(node.left == null && node.right == null)
                    return sum >= limit;
                
                bool left = DFS(node.left, sum);
                bool right = DFS(node.right, sum);

                if(!left)
                    node.left = null;
                
                if(!right)
                    node.right = null;
                
                return left || right;
            }

            return DFS(root, 0) ? root : null;
        }


    }
}
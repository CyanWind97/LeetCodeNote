using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2331
    /// title: 计算布尔二叉树的值
    /// problems: https://leetcode.cn/problems/evaluate-boolean-binary-tree/
    /// date: 20230206
    /// </summary>
    public static class Solution2331
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

        public static bool EvaluateTree(TreeNode root) {
            return root.val switch
            {
                0 => false,
                1 => true,
                2 => EvaluateTree(root.left) || EvaluateTree(root.right),
                3 => EvaluateTree(root.left) && EvaluateTree(root.right),
                _ => false,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1083
    /// title: 从二叉搜索树到更大和树
    /// problems: https://leetcode.cn/problems/binary-search-tree-to-greater-sum-tree/description/?envType=daily-question&envId=2023-12-04
    /// date: 20231204
    /// </summary>
    public static class Solution1083
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

        public static TreeNode BstToGst(TreeNode root) {

            int ReplaceNode(TreeNode node, int sum) {

                if (node.right != null)
                    sum = ReplaceNode(node.right, sum);
                
                sum += node.val;
                node.val = sum;
                
                if (node.left != null)
                    sum = ReplaceNode(node.left, sum);
                
                return sum;
            }

            ReplaceNode(root, 0);

            return root;
        }

        // 参考解答
        // Mirros 遍历
        public static TreeNode BstToGst_1(TreeNode root) {

            int sum = 0;
            TreeNode node = root;

            TreeNode GetSuccessor(TreeNode node) {
                TreeNode succ = node.right;
                while (succ.left != null && succ.left != node)
                    succ = succ.left;
                
                return succ;
            }

            while (node != null) {
                if (node.right == null) {
                    sum += node.val;
                    node.val = sum;
                    node = node.left;
                } else {
                    var succ = GetSuccessor(node);
                    if (succ.left == null) {
                        succ.left = node;
                        node = node.right;
                    } else {
                        succ.left = null;
                        sum += node.val;
                        node.val = sum;
                        node = node.left;
                    }
                }
            }

            return root;
        }
    }
}
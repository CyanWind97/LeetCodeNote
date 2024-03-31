using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 687
    /// title: 最长同值路径
    /// problems: https://leetcode.cn/problems/longest-univalue-path/
    /// date: 20220902
    /// </summary>
    public static class Solution687
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

        public static int LongestUnivaluePath(TreeNode root) {
            int longest = 0;
            
            int CalcUnivaluePath(TreeNode node, int value){
                if(node == null)
                    return 0;

                var l = CalcUnivaluePath(node.left, node.val);
                var r = CalcUnivaluePath(node.right, node.val);

                longest = Math.Max(longest, l + r);
                
                return node.val == value ? Math.Max(l, r) + 1 : 0;
            }

            CalcUnivaluePath(root, -1);

            return longest;
        }
    }
}
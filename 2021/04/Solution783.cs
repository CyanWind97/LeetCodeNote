using System;
using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 783
    /// title: 二叉搜索树节点最小距离
    /// problems: https://leetcode-cn.com/problems/minimum-distance-between-bst-nodes/
    /// date: 20210413
    /// </summary>
    public static class Solution783
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


        public static int MinDiffInBST(TreeNode root) {
            List<int> list = new List<int>();

            void Add(TreeNode node)
            {
                if(node.left != null)
                    Add(node.left);
                
                list.Add(node.val);

                if(node.right != null)
                    Add(node.right);
            }

            Add(root);

            int result = int.MaxValue;
            int length = list.Count;
            for(int i = 1; i < length; i++)
            {
                result = Math.Min(result, list[i] - list[i - 1]);
            }

            return result;
        }
        
    }
}
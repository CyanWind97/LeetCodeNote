using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 655
    /// title:  输出二叉树
    /// problems: https://leetcode.cn/problems/print-binary-tree/
    /// date: 20220822
    /// </summary>
    public static class Solution655
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

        public static IList<IList<string>> PrintTree(TreeNode root) {
            var height = 0;

            void CalcHeight(TreeNode node, int level){
                if(node.left == null && node.right == null){
                    height = Math.Max(level, height);
                }else{
                    if(node.left != null)
                        CalcHeight(node.left, level + 1);
                    
                    if(node.right != null)
                        CalcHeight(node.right, level + 1);
                }
            }
            
            CalcHeight(root, 0);

            var result = new IList<string>[height + 1];
            int n = (int)Math.Pow(2, height + 1) - 1;
            for(int i = 0; i < height + 1; i++){
                result[i] = new string[n];
                Array.Fill((string[])result[i], "");
            }

            void DFS(TreeNode node, int r, int c){
                result[r][c] = node.val.ToString();
                int d = (int)Math.Pow(2, height - r - 1);
                if(node.left != null)
                    DFS(node.left, r + 1, c - d);
                
                if(node.right != null)
                    DFS(node.right, r + 1, c + d);
            }

            DFS(root, 0, (n - 1) / 2);

            return result;
        }   
    }
}
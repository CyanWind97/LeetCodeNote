using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 671
    /// title: 二叉树中第二小的节点
    /// problems: https://leetcode-cn.com/problems/second-minimum-node-in-a-binary-tree/
    /// date: 20210727
    /// </summary>

    public static class Solution671
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


        public static int FindSecondMinimumValue(TreeNode root) {
            long GetSecondMin(TreeNode node){
                if(node.left == null)
                    return long.MaxValue;
                
                if(node.left.val != node.right.val){
                    if(node.left.val == node.val)
                        return Math.Min(GetSecondMin(node.left), node.right.val);
                    else
                        return Math.Min(GetSecondMin(node.right), node.left.val);
                }else{
                    long left = GetSecondMin(node.left);
                    long right = GetSecondMin(node.right);

                    return Math.Min(left, right);
                }
            }

            long result = GetSecondMin(root);

            return result == long.MaxValue ? -1 : (int)result;
        }

        // DFS
        public static int FindSecondMinimumValue_1(TreeNode root) {
            int result = -1;
            int rootvalue = root.val;

            void DFS(TreeNode node) {
                if (node == null) 
                    return;
                
                if (result != -1 && node.val >= result)
                    return;
                
                if (node.val > rootvalue)
                    result = node.val;
                
                DFS(node.left);
                DFS(node.right);
            }

            DFS(root);
            return result;
        }
    }
}
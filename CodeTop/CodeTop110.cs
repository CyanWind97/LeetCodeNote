using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 110
    /// title:  平衡二叉树
    /// problems: https://leetcode.cn/problems/balanced-binary-tree/
    /// date: 20220515
    /// priority: 0055
    /// time: 00:04:43.59
    /// </summary>
    public static class CodeTop110
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

        public static bool IsBalanced(TreeNode root) {
            
            bool TryGetLength(TreeNode node, out int h){
                h = 0;
                if(node == null)
                    return true;

                if(TryGetLength(node.left, out int leftH))
                    h = leftH;
                else
                    return false;
                
                if(TryGetLength(node.right, out int rightH))
                    h = Math.Max(rightH, h);
                else
                    return false;
                
                if(!(Math.Abs(leftH - rightH) <= 1))
                    return false;
                
                h++;

                return true;
            }

            return TryGetLength(root, out _);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1145
    /// title: 二叉树着色游戏
    /// problems: https://leetcode.cn/problems/binary-tree-coloring-game/
    /// date: 20230203
    /// </summary>
    public static class Solution1145
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

        public static bool BtreeGameWinningMove(TreeNode root, int n, int x) {
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode node = null;

            while(stack.Count > 0){
                node = stack.Pop();
                if(node.val == x)
                    break;
                
                if(node.left != null)
                    stack.Push(node.left);

                if(node.right != null)
                    stack.Push(node.right);
            }

            int GetSubSize(TreeNode node)
                => node == null ? 0 : 1 + GetSubSize(node.left) + GetSubSize(node.right);
            
            int left = GetSubSize(node.left);
            if(left >= (n + 1) / 2)
                return true;

            int right = GetSubSize(node.right);
            if(right >= (n + 1) / 2)
                return true;
            
            return left + right + 1 < (n + 1) / 2;
        }
    }
}
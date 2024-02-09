using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 94
/// title: 二叉树的中序遍历
/// problems: https://leetcode.cn/problems/binary-tree-inorder-traversal/description/?envType=daily-question&envId=2024-02-10
/// date: 20240210
/// </summary>
public static partial class Solution94
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

    public static IList<int> InorderTraversal(TreeNode root){
        const int WHITE = 0;
        const int GRAY = 1;
        var stack = new Stack<(int Color, TreeNode Node)>();
        var result = new List<int>();

        stack.Push((WHITE, root));

        while(stack.Count > 0){
            (var color, var node) = stack.Pop();

            if(node is null)
                continue;
            
            if(color == WHITE){
                stack.Push((WHITE, node.right));
                stack.Push((GRAY, node));
                stack.Push((WHITE, node.left));
            }else{
                result.Add(node.val);
            }
        }

        return result;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 889
/// title: 根据前序和后序遍历构造二叉树
/// problems: https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-postorder-traversal/description/?envType=daily-question&envId=2024-02-22
/// date: 20240222
/// </summary> 
public static class Solution889
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

    public static TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {        
        TreeNode Build(int preIndex, int postIndex, int size){
            if (size == 0)
                return null;

            var node = new TreeNode(preorder[preIndex]);
            if(size == 1)
                return node;
            
            int count = 1;
            while(preorder[preIndex + 1] != postorder[postIndex + count - 1])
                count++;
            
            node.left = Build(preIndex + 1, postIndex, count);
            node.right = Build(preIndex + count + 1, postIndex + count, size - count - 1);

            return node;
        }
        
        return Build(0, 0, preorder.Length);
    }
}

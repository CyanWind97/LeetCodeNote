using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1379
/// title: 找出克隆二叉树中的相同节点
/// problems: https://leetcode.cn/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree
/// date: 20240403
/// </summary>
public static class Solution1379
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public static TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        var queue = new Queue<(TreeNode Original, TreeNode Clone)>();
        queue.Enqueue((original, cloned));
        while(queue.Count > 0){
            var (node1, node2) = queue.Dequeue();
            if(node1 == target)
                return node2;
            
            if(node1.left is not null)
                queue.Enqueue((node1.left, node2.left));

            if(node1.right is not null)
                queue.Enqueue((node1.right, node2.right));
        }

        return null;
    }
}

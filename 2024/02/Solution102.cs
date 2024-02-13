using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 102
/// title: 二叉树的层序遍历
/// problems: https://leetcode.cn/problems/binary-tree-level-order-traversal/description/?envType=daily-question&envId=2024-02-14
/// date: 20240214
/// </summary>
public static class Solution102
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

    public static IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root is null)
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            int count = queue.Count;
            var list = new List<int>();
            for(int i = 0; i < count; i++){
                var node = queue.Dequeue();
                list.Add(node.val);
                if(node.left is not null)
                    queue.Enqueue(node.left);
                if(node.right is not null)
                    queue.Enqueue(node.right);
            }

            result.Add(list);
        }

        return result;
    }
}

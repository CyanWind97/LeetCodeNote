using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2641
/// title: 二叉树的堂兄弟节点 II
/// problems: https://leetcode.cn/problems/cousins-in-binary-tree-ii/description/?envType=daily-question&envId=2024-02-07
/// date: 20240207
/// </summary>
public static class Solution2641
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
    
    public static TreeNode ReplaceValueInTree(TreeNode root) {
        var queue = new Queue<(TreeNode Left, TreeNode Right)>();
        queue.Enqueue((root, null));

        while(queue.Count > 0){
            var list = new List<(TreeNode Left, TreeNode Right)>();
            while(queue.Count > 0){
                list.Add(queue.Dequeue());
            }

            int sum = list.Select(x => (x.Left?.val ?? 0) + (x.Right?.val ?? 0)).Sum();
            foreach(var (left, right) in list){
                if (left is null && right is null)
                    continue;

                var tmpSum = (left?.val ?? 0) + (right?.val ?? 0);

                if(left is not null){
                    left.val = sum - tmpSum;
                    queue.Enqueue((left.left, left.right));
                }
                if(right is not null){
                    right.val = sum - tmpSum;
                    queue.Enqueue((right.left, right.right));
                }
            }
        }

        return root;
    }
}

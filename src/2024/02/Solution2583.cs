using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2583
/// title: 二叉树中的第 K 大层和
/// problems: https://leetcode.cn/problems/kth-largest-sum-in-a-binary-tree/description/?envType=daily-question&envId=2024-02-23
/// date: 20240223
/// </summary> 
public static class Solution2583
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

    public static long KthLargestLevelSum(TreeNode root, int k) {
        var sums = new List<long>();
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            long sum = 0;
            int size = queue.Count;
            for(int i = 0; i < size; i++){
                var node = queue.Dequeue();
                sum += node.val;
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
            sums.Add(sum);
        }

        return k > sums.Count ? - 1 : sums.OrderByDescending(x => x).ElementAt(k - 1);
    }
}

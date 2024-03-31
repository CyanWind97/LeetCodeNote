using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 993
/// title: 二叉树的堂兄弟节点
/// problems: https://leetcode.cn/problems/cousins-in-binary-tree/description/?envType=daily-question&envId=2024-02-08
/// date: 20240208
/// </summary>
public static partial class Solution993
{
    public static bool IsCousins_1(TreeNode root, int x, int y) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root.left);
        queue.Enqueue(root.right);

        while(queue.Count > 0){
            int size = queue.Count;
            var xFound = false;
            var yFound = false;
            for(int i = 0; i < size; i += 2){
                var node1 = queue.Dequeue();
                var node2 = queue.Dequeue();
                
                if (node1?.val == x || node2?.val == x) {
                    xFound = true;
                    continue;
                }

                if (node1?.val == y || node2?.val == y) {
                    yFound = true;
                    continue;
                }

                if (node1 is not null){
                    queue.Enqueue(node1.left);
                    queue.Enqueue(node1.right);
                }

                if (node2 is not null){
                    queue.Enqueue(node2.left);
                    queue.Enqueue(node2.right);
                }
            }

            if(xFound && yFound)
                return true;
            if(xFound || yFound)
                return false;
        }

        return false;
    }
}

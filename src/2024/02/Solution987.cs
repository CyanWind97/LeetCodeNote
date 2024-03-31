using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote;

/// <summary>
/// no: 987
/// title: 二叉树的垂序遍历
/// problems: https://leetcode.cn/problems/vertical-order-traversal-of-a-binary-tree/description/?envType=daily-question&envId=2024-02-13
/// date: 20240213
/// </summary>
public static partial class Solution987
{
    public static IList<IList<int>> VerticalTraversal_1(TreeNode root) {
        var dic = new SortedDictionary<int, List<int>>();
        var queue = new Queue<(TreeNode Node, int Col)>();

        queue.Enqueue((root, 0));
        while(queue.Count > 0){
            int count = queue.Count;
            var currDic = new Dictionary<int, List<int>>();
            for(int i = 0; i < count; i++){
                var (node, col) = queue.Dequeue();
                if(!currDic.ContainsKey(col))
                    currDic.Add(col, new());
                
                currDic[col].Add(node.val);

                if(node.left != null)
                    queue.Enqueue((node.left, col - 1));
                
                if(node.right != null)
                    queue.Enqueue((node.right, col + 1));
            }

            foreach(var pair in currDic){
                if(!dic.ContainsKey(pair.Key))
                    dic.Add(pair.Key, new());
                
                pair.Value.Sort();
                dic[pair.Key].AddRange(pair.Value);
            }
        }

        return dic.Values.OfType<IList<int>>().ToList();
    }
}

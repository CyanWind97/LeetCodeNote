using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2476
/// title: 二叉搜索树最近节点查询
/// problems: https://leetcode.cn/problems/closest-nodes-queries-in-a-binary-search-tree/?envType=daily-question&envId=2024-02-24
/// date: 20240224
/// </summary> 

public static class Solution2476
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

    public static IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries) {
        var list = new List<int>();

        void InOrder(TreeNode node){
            if(node == null)
                return;
            InOrder(node.left);
            list.Add(node.val);
            InOrder(node.right);
        }

        InOrder(root);
        
        var result = new List<IList<int>>();
        foreach(var query in queries){
            int index = list.BinarySearch(query);
            if(index < 0){
                index = ~index;
                if(index == 0)
                    result.Add(new List<int>{-1, list[0]});
                else if(index == list.Count)
                    result.Add(new List<int>{list[^1], -1});
                else
                    result.Add(new List<int>{list[index - 1], list[index]});
            }else{
                result.Add(new List<int>{list[index], list[index]});
            }
        }

        return result;
    }
}

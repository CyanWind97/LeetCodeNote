using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 559
    /// title: N 叉树的最大深度
    /// problems: https://leetcode-cn.com/problems/maximum-depth-of-n-ary-tree/
    /// date: 20211121
    /// </summary>
    public static class Solution559
    {
        public class Node {
            public int val;
            public IList<Node> children;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, IList<Node> _children) {
                val = _val;
                children = _children;
            }
        }
        
        public static int MaxDepth(Node root) {
            if (root == null)
                return 0;

            int max = 1;
            foreach(var node in root.children){
                max = Math.Max(max, MaxDepth(node) + 1);
            }

            return max;
        }
    }
}
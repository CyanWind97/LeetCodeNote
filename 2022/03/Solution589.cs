using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 589
    /// title: N 叉树的前序遍历
    /// problems: https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal/
    /// date: 20220310
    /// </summary>
    public static class Solution589
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

        public static IList<int> Preorder(Node root) {
            IList<int> result = new List<int>();
            if (root == null) 
                return result;
            
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0) {
                Node node = stack.Pop();
                result.Add(node.val);

                for (int i = node.children.Count - 1; i >= 0; i--) {
                    stack.Push(node.children[i]);
                }
            }
            return result;
        }
    }
}
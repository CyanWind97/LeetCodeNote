using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 590
    /// title: N 叉树的后序遍历
    /// problems: https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal/
    /// date: 20220312
    /// </summary>
    public static class Solution590
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


        public static IList<int> Postorder(Node root) {
            var result = new List<int>();

            void PostorderHelper(Node node){
                
                foreach(var child in node.children){
                    PostorderHelper(child);
                }

                result.Add(node.val);
            }

            if(root != null)
                PostorderHelper(root);

            return result;
        }
    }
}
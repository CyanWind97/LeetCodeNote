using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 117
    /// title: 填充每个节点的下一个右侧节点指针 II
    /// problems: https://leetcode.cn/problems/populating-next-right-pointers-in-each-node-ii/description/?envType=daily-question&envId=2023-11-03
    /// date: 20231103
    /// </summary>
    public static class Solution117
    {
        // Definition for a Node.
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public static Node Connect(Node root) {
            if(root == null)
                return null;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0){
                int size = queue.Count;
                Node pre = null;
                for(int i = 0; i < size; i++){
                    var node = queue.Dequeue();
                    if(node.right != null)
                        queue.Enqueue(node.right);

                    if(node.left != null)
                        queue.Enqueue(node.left);
                    
                    node.next = pre;
                    pre = node;
                }
            }

            return root;
        }
    }
}
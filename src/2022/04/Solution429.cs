using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 429
    /// title: N 叉树的层序遍历
    /// problems: https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal/
    /// date: 20220408
    /// </summary>
    public static partial class Solution429
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

        public static IList<IList<int>> LevelOrder(Node root) {
            var result = new List<IList<int>>();

            if(root == null)
                return result;

            
            var nodes = new List<Node>();
            var children = new List<Node>();
            
            children.Add(root);

            while(children.Count > 0){
                nodes.AddRange(children);
                children.Clear();
                var nums = new List<int>();

                foreach(var node in nodes){
                    nums.Add(node.val);
                    children.AddRange(node.children ?? new Node[0]);
                }
                
                nodes.Clear();
                result.Add(nums);
            }
            
            return result;
        }


        // 参考 只用queue实现
        public static IList<IList<int>> LevelOrder_1(Node root) {
            var result = new List<IList<int>>();

            if(root == null)
                return result;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0){
                int count = queue.Count;
                var nums = new List<int>();

                for(int i = 0; i < count; i++){
                    var node = queue.Dequeue();
                    nums.Add(node.val);

                    foreach(var child in node.children){
                        queue.Enqueue(child);
                    }
                }

                result.Add(nums);
            }
            
            return result;
        }
    }
}
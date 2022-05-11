using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 449
    /// title: 序列化和反序列化二叉搜索树
    /// problems: https://leetcode.cn/problems/serialize-and-deserialize-bst/
    /// date: 20220511
    /// </summary>  
    public static class Solution449
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        // 后序遍历 令字符串尽可小
        public class Codec {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root) {
                var list = new List<int>();
                PostOrder(root, list);
                
                return string.Join(",", list);
            }

            private void PostOrder(TreeNode node, List<int> list){
                if(node == null)
                    return;
                
                PostOrder(node.left, list);
                PostOrder(node.right, list);
                list.Add(node.val);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data) {
                if(data.Length == 0)
                    return null;
                
                var nums = data.Split(",").Select(int.Parse).ToArray();
                var stack = new Stack<int>();
                int length = nums.Length;

                for(int i = 0; i < length; i++){
                    stack.Push(nums[i]);
                }
                
                return Construct(int.MinValue, int.MaxValue, stack);
            }

            private TreeNode Construct(int lower, int upper, Stack<int> stack){
                if(stack.Count == 0 || stack.Peek() < lower
                    || stack.Peek() > upper)
                    return null;
                
                int val = stack.Pop();
                var node = new TreeNode(val);
                node.right = Construct(val, upper, stack);
                node.left = Construct(lower, val, stack);

                return node;
            }
        }
    }
}
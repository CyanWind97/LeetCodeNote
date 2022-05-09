using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 297
    /// title:   二叉树的序列化与反序列化
    /// problems: https://leetcode-cn.com/problems/reverse-words-in-a-string/
    /// date: 20220507
    /// priority: 0017
    /// time: 00:25:10.71
    /// </summary>
    public static class CodeTop297
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public class Codec {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root) {
                var values = new List<int?>();
                var queue = new Queue<TreeNode>();

                queue.Enqueue(root);
                while(queue.Count > 0){
                    var node = queue.Dequeue();
                    values.Add(node?.val);
                    
                    if(node == null)
                        continue;
                    
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }

                while(values.Count > 0 && values.Last() == null){
                    values.RemoveAt(values.Count - 1);
                }

                return string.Join(",", values);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data) {
                var nodes = data.Split(",")
                                 .Select(s => string.IsNullOrEmpty(s) ? null : new TreeNode(int.Parse(s)))
                                 .ToArray();
                
                int length = nodes.Length;
                if(length == 0)
                    return null;
                
                int nullCount = 0;
                for(int i = 0; i < length; i++){
                    if(nodes[i] == null){
                        nullCount++;
                        continue;
                    }

                    int lefIndex = 2 * i + 1 - 2 * nullCount;
                    if(lefIndex < length)
                        nodes[i].left = nodes[lefIndex];

                    if(lefIndex + 1 < length)
                        nodes[i].right = nodes[lefIndex + 1];
                }

                return nodes[0];
            }
        }
    }
}
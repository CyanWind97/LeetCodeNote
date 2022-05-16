using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 428
    /// title: 序列化和反序列化n叉搜索树
    /// problems: https://leetcode.cn/problems/rotate-array/
    /// date: 20220516
    /// priority: 0069
    /// time: 00:17:11.36
    /// </summary> 
    public static class CodeTop428
    {
        public class TreeNode {
            public int val;
            public List<TreeNode> children;
            public TreeNode(int x) { val = x; }
        }


        public class Codec {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root) {
                var sb = new StringBuilder();

                void DFS(TreeNode node){
                    sb.Append(node.val);
                    int count = node.children == null
                                ? 0
                                : node.children.Count;
                    
                    if(count > 0){
                        sb.Append("[");
                        
                        for(int i = 0; i < count; i++){
                            DFS(node.children[i]);
                            if(i != count - 1)
                                sb.Append(",");
                        }

                        sb.Append("]");
                    }
                }

                DFS(root);

                return sb.ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data) {
                var stack = new Stack<TreeNode>();
                int length = data.Length;

                var num = 0;
                TreeNode node = new TreeNode(0);
                for(int i = 0; i < length; i++){
                    if(data[i] == '['){
                        node.val = num;
                        num = 0;
                        node.children = new List<TreeNode>();
                        
                        stack.Push(node);
                        node = new TreeNode(0);
                    }else if(char.IsDigit(data[i])){
                        num = num * 10 + data[i] - '0';
                    }else if(data[i] == ','){
                        if(num != 0){
                            node.val = num;
                            num = 0;
                        }

                        if(stack.Count > 0){
                            var tmp = stack.Peek();
                            tmp.children.Add(node);
                        }

                        node = new TreeNode(0);
                    }else if(data[i] == ']'){
                        if(num != 0){
                            node.val = num;
                            num = 0;
                        }
                        
                        var tmp = stack.Pop();
                        tmp.children.Add(node);
                        node = tmp;
                    }
                }

                return node;
            }
        }
    }
}
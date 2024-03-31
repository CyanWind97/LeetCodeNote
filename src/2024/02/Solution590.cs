using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 590
/// title: N 叉树的后序遍历
/// problems: https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal/
/// date: 20240219
/// </summary>
public partial class Solution590
{
    public static IList<int> Postorder_1(Node root) {
        var result = new List<int>();
        if (root is null)
            return result;
        
        var stack = new Stack<Node>();
        var visited = new Stack<Node>();
        stack.Push(root);
        
        while(stack.Count > 0){
            var node = stack.Peek();
            if(node.children.Count == 0 || visited.Contains(node)){
                result.Add(node.val);
                stack.Pop();
            }else{
                visited.Push(node);
                foreach(var child in node.children?.Reverse()){
                    stack.Push(child);
                }
            }
        }

        return result;
    }
}

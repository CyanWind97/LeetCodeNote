using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2385
/// title:  感染二叉树需要的总时间
/// problems: https://leetcode.cn/problems/amount-of-time-for-binary-tree-to-be-infected
/// date: 20240424
/// </summary>

public static class Solution2385
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

    public static int AmountOfTime(TreeNode root, int start) {
        var depths = new Dictionary<int, int>();
        var maxDepths = new Dictionary<int, (int Left, int Right)>();
        var parent = new Dictionary<int, TreeNode>();

        int Dfs(TreeNode node, int depth, TreeNode p) {
            if (node == null)
                return 0;

            parent[node.val] = p;
            depths[node.val] = depth;
            var left = Dfs(node.left, depth + 1, node);
            var right = Dfs(node.right, depth + 1, node);

            maxDepths[node.val] = (left, right);
            
            return Math.Max(left, right) + 1;
        }

        Dfs(root, 0, null);

        var result = Math.Max(maxDepths[start].Left, maxDepths[start].Right);
        
        int count = 1;
        while (parent.ContainsKey(start)) {
            var p = parent[start];
            if (p == null)
                break;

            int max = p.left?.val == start 
                    ? maxDepths[p.val].Right 
                    : p.right?.val == start 
                        ? maxDepths[p.val].Left 
                        : 0;

            result = Math.Max(result, max + count);
            start = p.val;
            count++;
        }

        return result;
    }

    // 参考解答
    // DFS 无需额外的数据结构
    public static int AmountOfTime_1(TreeNode root, int start) {
        int result = 0;

        (int Depth, int DistToStar) Dfs(TreeNode node) {
            if (node == null)
                return (0, int.MinValue);

            (var left, var lDis) = Dfs(node.left);
            (var right, var rDis) = Dfs(node.right);

            int dis = node.val == start 
                    ? 0 
                    : Math.Max(lDis, rDis);

            if (node.val == start)
                result = Math.Max(result, Math.Max(left, right));
            else if (rDis > 0)
                result = Math.Max(result, left + rDis);
            else if (lDis > 0)
                result = Math.Max(result, right + lDis);

            return (Math.Max(left, right) + 1, dis + 1);
        }

        Dfs(root);

        return result;
    }

     public static int AmountOfTime_2(TreeNode root, int start) {
        int result = 0;

        var visited = new Dictionary<TreeNode, (int, int)>();
        var stack = new Stack<(TreeNode, int, int)>();
        stack.Push((root, 1, root.val == start ? 0 : int.MinValue));

        while (stack.Count > 0) {
            var (node, depth, dist) = stack.Peek();

            if (!visited.ContainsKey(node)) {
                // Post-order: Push right & left children into the stack
                if (node.right is not null) 
                    stack.Push((node.right, depth + 1, int.MinValue));
                
                if (node.left is not null) 
                    stack.Push((node.left, depth + 1, int.MinValue));

                visited[node] = (depth, dist);
            } else {
                stack.Pop(); // Remove the node after its children are processed

                (int l, int lDist) = node.left != null ? visited[node.left] : (0, int.MinValue);
                (int r, int rDist) = node.right != null ? visited[node.right] : (0, int.MinValue);

                int currentDist = (node.val == start ? 0 : Math.Max(lDist, rDist)) + 1;
                visited[node] = (Math.Max(l, r) + 1, currentDist); // Update the visited dictionary

                if (node.val == start)
                    result = Math.Max(result, Math.Max(l, r));
                else if (rDist > 0)
                    result = Math.Max(result, l + rDist);
                else if (lDist > 0)
                    result = Math.Max(result, r + lDist);
            }
        }

        return result;
    }
}

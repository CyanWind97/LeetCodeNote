using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 863
    /// title: 二叉树中所有距离为 K 的结点
    /// problems: https://leetcode-cn.com/problems/all-nodes-distance-k-in-binary-tree/
    /// date: 20210728
    /// </summary>
    public static class Solution863
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
            var parents = new Dictionary<int, TreeNode>();

            void FindParents(TreeNode node){
                if(node.left != null){
                    parents.Add(node.left.val, node);
                    FindParents(node.left);
                }
                
                if(node.right != null){
                    parents.Add(node.right.val, node);
                    FindParents(node.right);
                }
            }

            List<int> GetList(TreeNode node, int depth){
                if(node == null)
                    return new List<int>(0);
                
                if(depth == 0)
                    return new List<int>(){node.val};
                
                var list = new List<int>();
                list.AddRange(GetList(node.left, depth - 1));
                list.AddRange(GetList(node.right, depth - 1));

                return list;
            }

            List<int> GetParentList(TreeNode node, TreeNode from, int depth){
                if(depth == 0)
                    return new List<int>(){node.val};

                var list = new List<int>();
                if(node.left != from)
                    list.AddRange(GetList(node.left, depth - 1));
                
                if(node.right != from)
                    list.AddRange(GetList(node.right, depth - 1));

                if(parents.ContainsKey(node.val))
                    list.AddRange(GetParentList(parents[node.val], node, depth - 1));

                return list;
            }

            FindParents(root);
            var result = GetList(target, k);
            if(parents.ContainsKey(target.val))
                result.AddRange(GetParentList(parents[target.val], target, k - 1));

            return result;
        }

    }
}


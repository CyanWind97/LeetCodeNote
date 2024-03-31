using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1110
    /// title: 删点成林
    /// problems: https://leetcode.cn/problems/delete-nodes-and-return-forest/
    /// date: 20230530
    /// </summary>
    public static class Solution1110
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

        public static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
            var result = new List<TreeNode>();
            var set = new HashSet<int>(to_delete);
            
            var queue = new Queue<(TreeNode Node, bool IsRoot, bool IsDelete)>();
            queue.Enqueue((root, true, set.Contains(root.val)));

            while(queue.Count > 0){
                (var node, var isRoot, var isDelete) = queue.Dequeue();
                if(!isDelete && isRoot)
                    result.Add(node);
                
                if(node.left != null){
                    var leftDelete = set.Contains(node.left.val);
                    queue.Enqueue((node.left, isDelete, leftDelete));
                    if(leftDelete)
                        node.left = null;
                }

                if(node.right != null){
                    var rightDelete = set.Contains(node.right.val);
                    queue.Enqueue((node.right, isDelete, rightDelete));
                    if(rightDelete)
                        node.right = null;
                }
                
            }

            return result;
        }
    }
}
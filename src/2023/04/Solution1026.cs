using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1026
    /// title:  节点与其祖先之间的最大差值
    /// problems: https://leetcode.cn/problems/maximum-difference-between-node-and-ancestor/
    /// date: 20230418
    /// </summary>
    public static partial class Solution1026
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

        public class Solution {
            public int MaxAncestorDiff(TreeNode root) {
                int maxDiff = 0;

                void DFS(TreeNode node, int min, int max){
                    
                    int val = node.val;
                    maxDiff = Math.Max(Math.Max(Math.Abs(val - min), 
                                                Math.Abs(max - val)),
                                        maxDiff);

                    min = Math.Min(min, val);
                    max = Math.Max(max, val);

                    if(node.left is not null)
                        DFS(node.left, min, max);

                    if(node.right is not null)
                        DFS(node.right, min, max);
                }

                DFS(root, root.val, root.val);

                return maxDiff;
            }
        }
    }
}
using System.ComponentModel;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 173
    /// title: 二叉搜索树迭代器
    /// problems: https://leetcode-cn.com/problems/binary-search-tree-iterator/
    /// date: 20210328
    /// </summary>
    public static class Solution173
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

        public class BSTIterator {
            
            List<int> list;

            int idx;

            public BSTIterator(TreeNode root) {
                list = new List<int>();
                void AddNode(TreeNode node){
                    if(node == null)
                        return;

                    AddNode(node.left);
                    list.Add(node.val);
                    AddNode(node.right);
                }

                AddNode(root);
            }
            
            public int Next() {
                return list[idx++];
            }
            
            public bool HasNext() {
                return idx < list.Count;
            }
        }
    }
}


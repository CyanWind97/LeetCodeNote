using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 173
    /// title:  二叉搜索树迭代器
    /// problems: https://leetcode.cn/problems/binary-search-tree-iterator/
    /// date: 20220515
    /// priority: 0060
    /// time: 00:07:28.33
    /// </summary>
    public static class CodeTop173
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
            private List<int> _list;

            private int _index;

            public BSTIterator(TreeNode root) {
                _list = new List<int>();
                _index = 0;

                var node = root;
                var stack = new Stack<TreeNode>();
                while(stack.Count > 0 || node != null){
                    while(node != null){
                        stack.Push(node);
                        node = node.left;
                    }

                    node = stack.Pop();
                    _list.Add(node.val);

                    node = node.right;
                }
            }
            
            public int Next() {
                return _list[_index++];
            }
            
            public bool HasNext() {
                return _index < _list.Count;
            }
        }
    }
}
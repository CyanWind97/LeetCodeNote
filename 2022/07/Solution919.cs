using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 919
    /// title: 完全二叉树插入器
    /// problems: https://leetcode.cn/problems/complete-binary-tree-inserter/
    /// date: 20220725
    /// </summary>
    public static class Solution919
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

        public class CBTInserter {

            private TreeNode _root;

            private Queue<TreeNode> _queue;

            public CBTInserter(TreeNode root) {
                _root = root;
                _queue = new();
                _queue.Enqueue(root);

                while(true){
                    var node = _queue.Peek();
                    if(node.left != null)
                        _queue.Enqueue(node.left);
                    else
                        break;
                    
                    if(node.right != null)
                        _queue.Enqueue(node.right);
                    else
                        break;

                    _queue.Dequeue();
                }
            }
            
            public int Insert(int val) {
                var parent = _queue.Peek();
                var result = parent.val;
                var node = new TreeNode(val);

                if(parent.left == null){
                    parent.left = node;
                }else{
                    parent.right = node;
                    _queue.Dequeue();
                }
                
                _queue.Enqueue(node);
                
                return result;
            }
            
            public TreeNode Get_root() {
                return _root;
            }
        }
    }
}
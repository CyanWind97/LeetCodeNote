using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1261
/// title: 在受污染的二叉树中查找元素
/// problems: https://leetcode.cn/problems/find-elements-in-a-contaminated-binary-tree
/// date: 20240312
/// </summary>
public static class Solution1261
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

    public class FindElements {
        private TreeNode _root;
        
        
        public FindElements(TreeNode root) {
            _root = root;
        }
        
        public bool Find(int target) {
            IEnumerable<bool> IsLeft(int num){
                if (num == 0)
                    yield break;
                
                foreach(var v in IsLeft((num - 1) / 2))
                    yield return v;
                
                yield return (num & 1) == 1;
            }

            var node = _root;
            foreach(var path in IsLeft(target)){
                if (path){
                    if (node.left == null)
                        return false;
                    
                    node = node.left;
                }else{

                    if (node.right == null)
                        return false;
                    
                    node = node.right;
                }
            }

            return true;
        }
    }

}

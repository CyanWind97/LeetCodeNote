using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 894
/// title: 所有可能的真二叉树
/// problems: https://leetcode.cn/problems/all-possible-full-binary-trees
/// date: 20240402
/// </summary>
public static class Solution894
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

    public static IList<TreeNode> AllPossibleFBT(int n) {
        var result = new List<TreeNode>();
        if(n % 2 == 0)
            return result;
        
        var possible = new IList<TreeNode>[n + 1];
    
        possible[1] = [new(0)];

        IList<TreeNode> GetPossible(int x){
            if(possible[x] is not null)
                return possible[x];
            
            var list = new List<TreeNode>();
            for(int i = 1; i < x; i += 2){
                var lefts = GetPossible(i);
                var rights = GetPossible(x - i - 1);
                foreach(var left in lefts){
                    foreach(var right in rights){
                        list.Add(new TreeNode(0, left, right));
                    }
                }
            }

            possible[x] = list;
            return list;
        }
        
        return GetPossible(n);
    }
}

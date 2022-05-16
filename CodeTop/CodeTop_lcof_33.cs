using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 33
    /// title: 二叉搜索树的后序遍历序列
    /// problems: https://leetcode.cn/problems/er-cha-sou-suo-shu-de-hou-xu-bian-li-xu-lie-lcof/
    /// date: 20220516
    /// type: 剑指Offer lcof
    /// priority: 0065
    /// time: 00:13:40.61
    /// </summary>
    public class CodeTop_lcof_33
    {
        // 参考解答 单调栈 反方向遍历
        public static bool VerifyPostorder(int[] postorder) {
            var stack = new Stack<int>();
            int root = int.MaxValue;
            for(int i = postorder.Length - 1; i >= 0; i--){
                if(postorder[i] > root)
                    return false;
                
                while(stack.Count > 0 && stack.Peek() > postorder[i])
                    root = stack.Pop();
                
                stack.Push(postorder[i]);
            }

            return true;
        }
    }
}
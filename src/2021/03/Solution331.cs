using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 331
    /// title: 验证二叉树的前序序列化
    /// problems: https://leetcode-cn.com/problems/verify-preorder-serialization-of-a-binary-tree/
    /// date: 20210312
    /// </summary>
    public static partial class Solution331
    {
        public static bool IsValidSerialization(string preorder) {
            int slots = 1;
            int i = 0;
            int length = preorder.Length;
            while(i < length){
                if(slots == 0)
                    return false;
                
                if(preorder[i] == ',')
                    i++;
                else if(preorder[i] == '#'){
                    slots--;
                    i++;
                }else{
                    while(i < length && preorder[i] != ','){
                        i++;
                    }
                    slots++;
                }
                    
            }

            return slots == 0;
        }
    }
}
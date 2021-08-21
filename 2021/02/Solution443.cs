using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 443
    /// title: 压缩字符串
    /// problems: https://leetcode-cn.com/problems/string-compression/
    /// date: 20210204
    /// </summary>
    public static partial class Solution443
    {
        public static int Compress(char[] chars) {
            int length = chars.Length;
            if(length < 2)
                return length;
            
            int left = 0;
            int right = 0;
            int index = 0;
            
            while(right < length){
                if(chars[left] != chars[right]){
                    chars[index++] = chars[left];
                    if(right - left > 1){
                        foreach(var d in (right - left).ToString()){
                            chars[index++] = d;
                        }
                    }
                    
                    left = right;
                }

                right++;
            }
            chars[index++] = chars[left];
            if(right - left > 1){
                foreach(var d in (right - left).ToString()){
                    chars[index++] = d;
                }
            }

            return index;
        }

    }
}
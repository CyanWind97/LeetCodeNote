using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 661
    /// title: 图片平滑器
    /// problems: https://leetcode-cn.com/problems/image-smoother/
    /// date: 20220324
    /// </summary>
    public static partial class Solution661
    {
        public static int[][] ImageSmoother(int[][] img) {
            int m = img.Length;
            int n = img[0].Length;
            
            IEnumerable<int> GetPixels(int x, int y){
                var maxX = Math.Min(x + 1, m - 1);
                var maxY = Math.Min(y + 1, n - 1);
                for(int i = Math.Max(x - 1, 0); i <= maxX; i++){
                    for(int j = Math.Max(y - 1, 0); j <= maxY; j++){
                        yield return img[i][j];
                    }
                }
            }

            var result = new int[m][];

            for(int i = 0; i < m; i++){
                result[i] = new int[n];

                for(int j = 0; j < n; j++){
                    result[i][j] = (int)Math.Floor(GetPixels(i, j).Average());
                }
            }

            return result;
        }
    }
}
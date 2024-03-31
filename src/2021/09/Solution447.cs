using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 447
    /// title: 回旋镖的数量
    /// problems: https://leetcode-cn.com/problems/number-of-boomerangs/
    /// date: 20210913
    /// </summary>
    public static partial class Solution447
    {
        public static int NumberOfBoomerangs(int[][] points) {
            int length = points.Length;
            int result = 0;

            for(int i = 0; i < length - 2; i++){
                (int X, int Y) p1 = (points[i][0], points[i][1]);
                for(int j = i + 1; j < length - 1; j++){
                    (int X, int Y) p2 = (points[j][0], points[j][1]);
                    for(int k = j + 1; k < length; k++){
                        (int X, int Y) p3 = (points[k][0], points[k][1]);
                        int d1 = (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
                        int d2 = (p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y);
                        int d3 = (p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y);
                        
                        if(d1 == d2 || d2 == d3 || d3 == d1)
                            result += 2;
                    }
                }
            }

            return result;
        }

        // 字典， 去除重复计算
        public static int NumberOfBoomerangs_1(int[][] points) {
            int length = points.Length;
            int result = 0;

            for(int i = 0; i < length; i++){
                (int X, int Y) p1 = (points[i][0], points[i][1]);
                var dic = new Dictionary<int, int>();
                for(int j = 0; j < length; j++){
                    (int X, int Y) p2 = (points[j][0], points[j][1]);
                    int d = (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
                    if(!dic.ContainsKey(d))
                        dic.Add(d, 0);
                    
                    dic[d]++;
                }

                foreach(var count in dic.Values){
                    result += count * (count - 1);
                }
            }

            return result;
        }
    }
}
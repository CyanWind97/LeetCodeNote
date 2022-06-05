using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 478
    /// title: 在圆内随机生成点
    /// problems: https://leetcode.cn/problems/generate-random-point-in-a-circle/
    /// date: 20220605
    /// </summary>
    public static class Solution478
    {
        public class Solution {

            private (double X, double Y) _center;

            private double _radius;

            private Random _random;

            public Solution(double radius, double x_center, double y_center) {
                _radius = radius;
                _center = (x_center, y_center);
                _random = new Random();
            }
            
            // 参考解答 计算raius时没考虑开平方，保证均匀
            public double[] RandPoint() {
                var radius =  Math.Sqrt(_random.NextDouble()) * _radius;
                var angle = 2 * Math.PI * _random.NextDouble();  
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                return new double[]{x + _center.X, y + _center.Y};
            }
        }
    }
}
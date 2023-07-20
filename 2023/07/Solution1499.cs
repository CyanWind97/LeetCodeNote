using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1499
    /// title:  满足不等式的最大值
    /// problems: https://leetcode.cn/problems/max-value-of-equation/
    /// date: 20230721
    /// </summary>
    public static class Solution1499
    {
        public static int FindMaxValueOfEquation(int[][] points, int k) {
            int result = int.MinValue;
            var queue = new PriorityQueue<(int Value, int Index), int>();
            
            foreach(var point in points){
                (int x, int y) = (point[0], point[1]);
                while(queue.Count > 0 && x - queue.Peek().Index > k)
                    queue.Dequeue();
                
                if(queue.Count > 0)
                    result = Math.Max(result, x + y + queue.Peek().Value);
                
                queue.Enqueue((y - x, x), x - y);
            }

            return result;
        }

        public static int  FindMaxValueOfEquation_1(int[][] points, int k){
            int length = points.Length;
            int result = int.MinValue;
            var queue = new (int Value, int Index)[length];
            int left = 0;
            int right = 0;

            foreach(var point in points){
                (int x, int y) = (point[0], point[1]);
                while(left < right && x - queue[left].Index > k)
                    left++;
                
                if(left < right)
                    result = Math.Max(result, x + y + queue[left].Value);
                
                while(left < right && y - x >= queue[right - 1].Value)
                    right--;
                
                queue[right++] = (y - x, x);
            }

            return result;
        }
    }
}
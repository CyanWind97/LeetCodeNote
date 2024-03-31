using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1792
    /// title: 最大平均通过率
    /// problems: https://leetcode.cn/problems/maximum-average-pass-ratio/
    /// date: 20230219
    /// </summary>
    public static class Solution1792
    {
        public static double MaxAverageRatio(int[][] classes, int extraStudents) {
            var queue = new PriorityQueue<(int Pass, int Total), double>();

            double GetDiffRatio(int pass, int total)
                => (double)(pass + 1) / (total + 1) - (double)pass / total;
            

            foreach(var info in classes){
                (int pass, int total) = (info[0], info[1]);
                queue.Enqueue((pass, total), -GetDiffRatio(pass, total));
            }

            for(int i = 0; i < extraStudents; i++){
                (int pass, int total) = queue.Dequeue();
                queue.Enqueue((pass + 1, total + 1), -GetDiffRatio(pass + 1, total + 1));
            }

            IEnumerable<double> GetRatio(){
                while(queue.Count > 0){
                    (int pass, int total) = queue.Dequeue();
                    yield return (double)pass / total;
                }
            }

            return GetRatio().Average();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 210
    /// title: 课程表 II
    /// problems: https://leetcode.cn/problems/course-schedule-ii/?envType=daily-question&envId=2023-09-10
    /// date: 20230910
    /// </summary>
    public class Solution210
    {
        public static int[] FindOrder(int numCourses, int[][] prerequisites) {
            var degrees = new int[numCourses];
            var nextCourses = new IList<int>[numCourses];
            var result = new int[numCourses];
            
            for(int i = 0; i < numCourses; i++){
                nextCourses[i] = new List<int>();
            }

            foreach(var prerequisite in prerequisites){
                degrees[prerequisite[0]]++;
                nextCourses[prerequisite[1]].Add(prerequisite[0]);
            }

            var queue = new Queue<int>();
            for(int i = 0; i < numCourses; i++){
                if(degrees[i] == 0){
                    queue.Enqueue(i);
                }
            }

            var index = 0;

            while(queue.Count > 0){
                var cur = queue.Dequeue();
                result[index++] = cur;
                
                foreach(var next in nextCourses[cur]){
                    degrees[next]--;
                    if(degrees[next] == 0)
                        queue.Enqueue(next);
                }
            }

            return index == numCourses ? result : new int[]{};
        }
    }
}
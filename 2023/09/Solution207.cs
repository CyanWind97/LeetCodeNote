using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 207
    /// title: 课程表
    /// problems: https://leetcode.cn/problems/course-schedule/?envType=daily-question&envId=2023-09-09
    /// date: 20230909
    /// </summary>

    public static class Solution207
    {
        public static  bool CanFinish(int numCourses, int[][] prerequisites) {
            var queue = new Queue<int>();
            var parents = new List<int>[numCourses];
            var outDegrees = new int[numCourses];

            for(int i = 0; i < numCourses; i++){
                parents[i] = new List<int>();
            }

            foreach(var pair in prerequisites){
                parents[pair[0]].Add(pair[1]);
                outDegrees[pair[1]]++;
            }

            for(int i = 0; i < numCourses; i++){
                if(outDegrees[i] == 0)
                    queue.Enqueue(i);
            }

            while(queue.Count > 0){
                var num = queue.Dequeue();

                foreach(var parent in parents[num]){
                    outDegrees[parent]--;
                    if(outDegrees[parent] == 0)
                        queue.Enqueue(parent);
                }
            }


            return outDegrees.All(outDegree => outDegree == 0);
        }
    }
}
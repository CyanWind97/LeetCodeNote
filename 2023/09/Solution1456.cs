using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1456
    /// title: 课程表 IV
    /// problems: https://leetcode.cn/problems/course-schedule-iv/?envType=daily-question&envId=2023-09-12
    /// date: 20230912
    /// </summary>
    public static class Solution1456
    {
        public static IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
            var graph = Enumerable.Range(0, numCourses).Select(i => new List<int>()).ToArray();
            var degrees = new int[numCourses];
            var isPre = new bool[numCourses, numCourses];

            foreach(var p in prerequisites){
                graph[p[0]].Add(p[1]);
                degrees[p[1]]++;
            }

            var queue = new Queue<int>(Enumerable.Range(0, numCourses).Where(i => degrees[i] == 0));
            while(queue.Any()){
                var curr = queue.Dequeue();
                foreach(var next in graph[curr]){
                    isPre[curr, next] = true;
                    for(int i = 0; i < numCourses; i++){
                        isPre[i, next] = isPre[i, next] || isPre[i, curr];
                    }

                    --degrees[next];
                    if(degrees[next] == 0)
                        queue.Enqueue(next);
                }
            }

            return queries.Select(q => isPre[q[0], q[1]]).ToArray();
        }
    }
}
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 210
    /// title:  课程表 II
    /// problems: https://leetcode.cn/problems/course-schedule-ii/
    /// date: 20220511
    /// priority: 0032
    /// time: 00:12:17.93
    /// </summary>
    public static class CodeTop210
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
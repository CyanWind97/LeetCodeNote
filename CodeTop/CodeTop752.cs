using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 752
    /// title:  打开转盘锁
    /// problems: https://leetcode.cn/problems/open-the-lock/
    /// date: 20220513
    /// priority: 0044
    /// time: 00:19:13.70
    /// </summary>
    public static class CodeTop752
    {
        public static int OpenLock(string[] deadends, string target) {
            var visited = deadends.ToHashSet();

            IEnumerable<string> GetAccess(string s){
                var chars = s.ToCharArray();

                for(int i = 0; i < 4; i++){
                    var c = s[i];
                    
                    chars[i] = c == '9' ? '0' : (char)(c + 1);
                    var tmp = new string(chars);
                    if(visited.Add(tmp))
                        yield return tmp;
                    
                    chars[i] = c == '0' ? '9' : (char)(c - 1);
                    tmp = new string(chars);
                    if(visited.Add(tmp))
                        yield return tmp;

                    chars[i] = c;
                }
            }

            if(!visited.Add("0000"))
                return -1;

            var queue = new Queue<(string S, int Count)>();
            queue.Enqueue(("0000", 0));

            while(queue.Count > 0){
                (var s, var count)= queue.Dequeue();
                if(s == target)
                    return count;
                
                foreach(var next in GetAccess(s)){
                    queue.Enqueue((next, count + 1));
                }
            }

            return -1;
        }

        // AStart
        public static int OpenLock_1(string[] deadends, string target) {
            var visited = deadends.ToHashSet();

            IEnumerable<string> GetAccess(string s){
                var chars = s.ToCharArray();

                for(int i = 0; i < 4; i++){
                    var c = s[i];
                    
                    chars[i] = c == '9' ? '0' : (char)(c + 1);
                    var tmp = new string(chars);
                    if(visited.Add(tmp))
                        yield return tmp;
                    
                    chars[i] = c == '0' ? '9' : (char)(c - 1);
                    tmp = new string(chars);
                    if(visited.Add(tmp))
                        yield return tmp;

                    chars[i] = c;
                }
            }

            int CalcDistance(string s){
                int dis = 0;
                for(int i = 0; i < 4; i++){
                    int diff = Math.Abs(s[i] - target[i]);
                    dis += Math.Min(10 - diff, diff);
                }
                
                return dis;
            }

            if(!visited.Add("0000"))
                return -1;

            var priorityQueue = new PriorityQueue<(string S, int Count, int Dist), int>();
            
            int dis0 = CalcDistance("0000");
            priorityQueue.Enqueue(("0000", 0, dis0), dis0);

            while(priorityQueue.Count > 0){
                (var s, int count, int dis) = priorityQueue.Dequeue();
                if(dis == 0)
                    return count;
                
                foreach(var next in GetAccess(s)){
                    var nextDis = CalcDistance(next);
                    priorityQueue.Enqueue((next, count + 1, nextDis), nextDis + count + 1);
                }
            }

            return -1;
        }
    }
}
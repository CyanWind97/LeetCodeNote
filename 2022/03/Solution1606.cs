using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1606
    /// title: 找到处理最多请求的服务器
    /// problems: https://leetcode-cn.com/problems/find-servers-that-handled-most-number-of-requests/
    /// date: 20220330
    /// </summary>
    public static class Solution1606
    {
        public static IList<int> BusiestServers(int k, int[] arrival, int[] load) {
            int[] count = new int[k];
            bool[] isFree = new bool[k];
            Array.Fill(isFree, true);

            var freeMaps = new SortedDictionary<int, List<int>>();

            int length = arrival.Length;
            for(int i = 0; i < length; i++){
                var time = arrival[i];

                while(freeMaps.Count > 0 ){
                    var top = freeMaps.First();
                    if(top.Key > time)
                        break;
                    
                    foreach(var server in top.Value){
                        isFree[server] = true;
                    }

                    freeMaps.Remove(top.Key);
                }
                
                var cur = i % k;
                var freeServer = Array.IndexOf(isFree, true, cur);
                if(freeServer == -1){
                    freeServer = Array.IndexOf(isFree, true, 0, cur);
                    if(freeServer == -1)
                        continue;
                }
                
                var finish = time + load[i];
                if(freeMaps.ContainsKey(finish))
                    freeMaps[finish].Add(freeServer);
                else
                    freeMaps.Add(finish, new List<int>(){freeServer});
                
                count[freeServer]++;
                isFree[freeServer] = false;
            }

            var result = new List<int>();
            int max = 0;
            for(int i = 0; i < k; i++){
                if(count[i] < max)
                    continue;
                
                if(count[i] > max){
                    max = count[i];
                    result.Clear();
                }
                
                result.Add(i);
            }

            return result;
        }

        // 优先队列
        public static IList<int> BusiestServers_1(int k, int[] arrival, int[] load) {
            int[] count = new int[k];
            bool[] isFree = new bool[k];
            Array.Fill(isFree, true);

            var busyQueue = new PriorityQueue<(int Time, int Server), int>();

            int length = arrival.Length;
            for(int i = 0; i < length; i++){
                var time = arrival[i];

                while(busyQueue.Count > 0 ){
                    var top = busyQueue.Peek();
                    if(top.Time > time)
                        break;
                    
                    isFree[top.Server] = true;
                    busyQueue.Dequeue();
                }
                
                var cur = i % k;
                var freeServer = Array.IndexOf(isFree, true, cur);
                if(freeServer == -1){
                    freeServer = Array.IndexOf(isFree, true, 0, cur);
                    if(freeServer == -1)
                        continue;
                }
                
                var finish = time + load[i];
                busyQueue.Enqueue((finish, freeServer), finish);
                
                count[freeServer]++;
                isFree[freeServer] = false;
            }

            var result = new List<int>();
            int max = 0;
            for(int i = 0; i < k; i++){
                if(count[i] < max)
                    continue;
                
                if(count[i] > max){
                    max = count[i];
                    result.Clear();
                }
                
                result.Add(i);
            }

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 433
    /// title: 最小基因变化
    /// problems: https://leetcode-cn.com/problems/minimum-genetic-mutation/
    /// date: 20220507
    /// </summary>
    public static  class Solution433
    {
        public static int MinMutation(string start, string end, string[] bank) {
            int length = bank.Length;

            if(length == 0)
                return -1;

            bool IsAcessible(string source, string target)
                => Enumerable.Range(0, 8).Count(i => source[i] != target[i]) == 1; 

            var access = new bool[length, length];
            int startIndex = -1;
            int endIndex = -1;

            for(int i = 0; i < length; i++){
                if(bank[i] == start)
                    startIndex = i;
                else if(bank[i] == end)
                    endIndex = i;
                
                for(int j = i + 1; j < length; j++){
                    bool flag = IsAcessible(bank[i], bank[j]);
                    access[i, j] = flag;
                    access[j, i] = flag;
                }
            }
            
            if(endIndex == -1)
                return - 1;

            var visited = new bool[length];
            var queue = new Queue<(int Index, int Count)>();

            if(startIndex != -1){
                visited[startIndex] = true;
                queue.Enqueue((startIndex, 0));
            }else{
                for(int i = 0; i < length; i++){
                    if(!IsAcessible(start, bank[i]))
                        continue;
                    
                    visited[i] = true;
                    queue.Enqueue((i, 1));
                }
            }

            while(queue.Count > 0){
                (var index, int count) = queue.Dequeue();

                if(index == endIndex)
                    return count;

                for(int i = 0; i < length; i++){
                    if(visited[i] || !access[index, i])
                        continue;
                    
                    visited[i] = true;
                    queue.Enqueue((i, count + 1));
                }
            }

            return -1;
        }
    }
}
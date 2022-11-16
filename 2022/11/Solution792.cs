using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 792
    /// title: 匹配子序列的单词数
    /// problems: https://leetcode.cn/problems/number-of-matching-subsequences/
    /// date: 20221117
    /// </summary> 
    public static class Solution792
    {   
        // 参考解答
        // 多指针
        public static int NumMatchingSubseq(string s, string[] words) {
            var queues = Enumerable.Range(0, 26)
                            .Select(i => new Queue<(int Index, int Pos)>())
                            .ToArray();
            
            for(int i = 0; i < words.Length; i++){
                queues[words[i][0] - 'a'].Enqueue((i, 0));
            }

            int result = 0;
            
            foreach(var c in s){
                int count = queues[c - 'a'].Count;
                while(count > 0){
                    (int i, int j) = queues[c - 'a'].Dequeue();
                    if(j == words[i].Length - 1){
                        result++;
                    }else{
                        j++;
                        queues[words[i][j] - 'a'].Enqueue((i, j));
                    }

                    count--;
                }
            }

            return result;
        }
    }
}
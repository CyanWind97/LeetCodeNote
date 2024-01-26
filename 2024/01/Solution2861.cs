using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2861
    /// title: 最大合金数
    /// problems: https://leetcode.cn/problems/maximum-number-of-alloys/description/?envType=daily-question&envId=2024-01-27
    /// date: 20240127
    /// </summary>
    public static class Solution2861
    {
        public static int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost) {

            int MaxProduce(IList<int> standard){
                int spend = 0;
                int oneSpend = 0;
                int result = 0;
                
                var pq = new PriorityQueue<(int Count, int Index), int>();
                for(int i = 0; i < n; i++){
                    int count = stock[i] / standard[i];
                    pq.Enqueue((count, i), count);
                }


                while(pq.Count > 0){
                    (result, int index) = pq.Dequeue();
                    var list = new List<int>(){index};
                    
                    while(pq.Count > 0 && pq.Peek().Count == result){
                        (_, index) = pq.Dequeue();
                        list.Add(index);
                    }

                    foreach(var i in list){
                        spend -= (stock[i] % standard[i]) * cost[i];
                        oneSpend += standard[i] * cost[i];
                    }

                    int nextCount = pq.Count > 0 ? pq.Peek().Count : 0;
                    int nextSpend = spend + (nextCount - result) * oneSpend;
                    if(nextCount == 0 || nextSpend > budget)
                        break;
                    else 
                        spend = nextSpend;
                }

                result += (budget - spend) / oneSpend;

                return result;
            }

            return composition.Max(x => MaxProduce(x));
        }
    }
}
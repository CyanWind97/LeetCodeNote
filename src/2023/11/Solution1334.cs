using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1334
    /// title: 阈值距离内邻居最少的城市
    /// problems: https://leetcode.cn/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/description/?envType=daily-question&envId=2023-11-14
    /// date: 20231114
    /// </summary>
    public static class Solution1334
    {
        public static int FindTheCity(int n, int[][] edges, int distanceThreshold) {
            int[,] distance = new int[n,n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    distance[i,j] = int.MaxValue;
                }
            }

            foreach(var edge in edges){
                distance[edge[0], edge[1]] = edge[2];
                distance[edge[1], edge[0]] = edge[2];
            }

            for(int i = 0; i < n; i++){
                distance[i,i] = 0;
            }

            for(int k = 0; k < n; k++){
                for(int i = 0; i < n; i++){
                    for(int j = i + 1; j < n; j++){
                        if(distance[i,k] == int.MaxValue 
                        || distance[k,j] == int.MaxValue)
                            continue;

                        distance[i,j] = Math.Min(distance[i,j], distance[i,k] + distance[k,j]);
                        distance[j,i] = distance[i,j];
                    }
                }
            }

            int min = int.MaxValue;
            int result = 0;
            for(int i = 0; i < n; i++){
                int count = 0;
                for(int j = 0; j < n; j++){
                    if(distance[i,j] <= distanceThreshold)
                        count++;
                }

                if(count <= min){
                    min = count;
                    result = i;
                }
            }

            return result;
        }
    }
}
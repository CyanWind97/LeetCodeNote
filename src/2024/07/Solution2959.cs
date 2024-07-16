using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2959
/// title: 关闭分部的可行集合数目
/// problems: https://leetcode.cn/problems/number-of-possible-sets-of-closing-branches
/// date: 20240717
/// </summary>
public static class Solution2959
{
    // 参考解答
    // Floyd
    public static int NumberOfSets(int n, int maxDistance, int[][] roads) {
        int result = 0;
        var opened = new int[n];
        var d = new int[n, n];

        for(int mask = 0; mask < (1 << n); mask++){
            for(int i = 0; i < n; i++){
                opened[i] = mask & (1 << i);
            }

            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    d[i, j] = 1000000;
                }
            }

            foreach(var road in roads){
                var (i, j, r) = (road[0], road[1], road[2]);
                if(opened[i] > 0 && opened[j] > 0){
                    d[i, j] = d[j, i] = Math.Min(d[i, j], r);
                }
            }

            for(int k = 0; k < n; k++){
                if(opened[k] == 0)
                    continue;
                
                for(int i = 0; i < n; i++){
                    if(opened[i] == 0)
                        continue;
                    
                    for(int j = i + 1; j < n; j++){
                        if(opened[j] == 0)
                            continue;
                        
                        d[i, j] = d[j, i] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                    }
                }
            }

            int good = 1;
            for(int i = 0; i < n; i++){
                if(opened[i] == 0)
                    continue;
                
                for(int j = i + 1; j < n; j++){
                    if (opened[j] == 0)
                        continue;
                    
                    if(d[i, j] > maxDistance){
                        good = 0;
                        break;
                    }
                }

                if (good == 0)
                    break;
            }

            result += good;
        }

        return result;
    }
}

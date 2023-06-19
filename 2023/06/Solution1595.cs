using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1595
    /// title: 连通两组点的最小成本
    /// problems: https://leetcode.cn/problems/minimum-cost-to-connect-two-groups-of-points/
    /// date: 20230620
    /// </summary>
    public static class Solution1595
    {   
        // 参考解答
        // 状态压缩
        public static int ConnectTwoGroups(IList<IList<int>> cost) {
            int size1 = cost.Count;
            int size2 = cost[0].Count;
            int m = 1 << size2;

            var dp1 = Enumerable.Repeat(int.MaxValue / 2, m).ToArray();
            var dp2 =  new int[m];
            dp1[0] = 0;
            for(int i = 0; i < size1; i++){
                for(int s = 0; s < m; s++){
                    dp2[s] = int.MaxValue / 2;
                    for(int k = 0; k < size2; k++){
                        if ((s & (1 << k)) is 0)
                            continue;
                        
                        var pre = s ^ (1 << k);
                        dp2[s] = Math.Min(dp2[s], dp2[pre] + cost[i][k]);
                        dp2[s] = Math.Min(dp2[s], dp1[s] + cost[i][k]);
                        dp2[s] = Math.Min(dp2[s], dp1[pre] + cost[i][k]);
                    }
                }

                Array.Copy(dp2, dp1, m);
            }

            return dp1[m - 1];
        }
    }
}
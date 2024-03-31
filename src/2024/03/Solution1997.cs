using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1997
/// title: 访问完所有房间的第一天
/// problems: https://leetcode.cn/problems/first-day-where-you-have-been-in-all-the-rooms
/// date: 20240328
/// </summary>
public static class Solution1997
{
    public static int FirstDayBeenInAllRooms(int[] nextVisit) {
        int mod = 1_000_000_007;
        int n = nextVisit.Length;
        var visited = new int[n];
        var days = new long[n, 2];
        long day = 0;
        int count = 1; 
        int index = 0;
        
        while(count < n){
            visited[index]++;
            int odd = visited[index] % 2 == 1 ? 1 : 0;
            days[index, odd] = day;

            var next = odd == 1
                    ? nextVisit[index]
                    : (index + 1) % n;
            
            if(visited[next] > 0){
                int nextOdd = visited[next] % 2;
                day = (day + (mod + day - days[next, nextOdd] + 1)) % mod; 
                days[index, (1 - odd)] = day;
                next = (1 - odd) == 1 ? nextVisit[index] : (index + 1) % n;
            }
            
            index = next;
            day++;
            count++;
        }

        return (int)day;
    }

    // 参考解答
    // shit nextVisit[i] <= i
    public static int FirstDayBeenInAllRooms_1(int[] nextVisit) {
        int mod = 1_000_000_007;
        int n = nextVisit.Length;
        var dp = new int[n];

        dp[0] = 2;
        for(int i = 1; i < n; i++){
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            if (to is not 0)
                dp[i] = (dp[i] - dp[to -1] + mod) % mod;
            
            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }

        return dp[^2];
    }
}

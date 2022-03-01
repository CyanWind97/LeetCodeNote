using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1601
    /// title: 最多可达成的换楼请求数目
    /// problems: https://leetcode-cn.com/problems/maximum-number-of-achievable-transfer-requests/
    /// date: 20220228
    /// </summary>
    public class Solution1601
    {   
        // 参考解答 DFS + 枚举
        public static  int MaximumRequests(int n, int[][] requests) {
            var delta = new int[n];
            var zero = n;
            var result = 0;
            var count = 0;
            
            void DFS(int pos) {
                if (pos == requests.Length) {
                    if (zero == n) 
                        result = Math.Max(result, count);
                    
                    return;
                }

                // 不选 requests[pos]
                DFS(pos + 1);

                // 选 requests[pos]
                int z = zero;
                ++count;
                int[] r = requests[pos];
                int x = r[0], y = r[1];
                zero -= delta[x] == 0 ? 1 : 0;
                --delta[x];
                zero += delta[x] == 0 ? 1 : 0;
                zero -= delta[y] == 0 ? 1 : 0;
                ++delta[y];
                zero += delta[y] == 0 ? 1 : 0;
                DFS(pos + 1);
                --delta[y];
                ++delta[x];
                --count;
                zero = z;
            }

            DFS(0);

            return result;
        }

        // 参考解答 二进制枚举
        public static int MaximumRequests_1(int n, int[][] requests) {
            int[] delta = new int[n];
            int result = 0;
            int m = requests.Length;

            for (int mask = 0; mask < (1 << m); ++mask) {
                int cnt = BitCount(mask);
                if (cnt <= result) 
                    continue;
                
                Array.Fill(delta, 0);
                for (int i = 0; i < m; ++i) {
                    if ((mask & (1 << i)) != 0) {
                        ++delta[requests[i][0]];
                        --delta[requests[i][1]];
                    }
                }
                
                if (delta.All(x => x == 0)) 
                    result = cnt;
                
            }
            return result;
        }

        private static int BitCount(int i) {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }
    }

}
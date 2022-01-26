using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2013
    /// title: 检测正方形
    /// problems: https://leetcode-cn.com/problems/detect-squares/
    /// date: 20220126
    /// </summary>
    public static class Solution2013
    {
        public class DetectSquares {
            Dictionary<int, Dictionary<int, int>> cnt;

            public DetectSquares() {
                cnt = new Dictionary<int, Dictionary<int, int>>();
            }

            public void Add(int[] point) {
                int x = point[0], y = point[1];
                if (!cnt.ContainsKey(y)) 
                    cnt.Add(y, new Dictionary<int, int>());
                
                var yCnt = cnt[y];
                if (!yCnt.ContainsKey(x))
                    yCnt.Add(x, 0);
                
                yCnt[x]++;
            }

            public int Count(int[] point) {
                int res = 0;
                int x = point[0], y = point[1];
                if (!cnt.ContainsKey(y)) 
                    return 0;
                
                var yCnt = cnt[y];
                foreach(var pair in cnt) {
                    int col = pair.Key;
                    Dictionary<int, int> colCnt = pair.Value;
                    if (col != y) {
                        // 根据对称性，这里可以不用取绝对值
                        int d = col - y;
                        int cnt1 = colCnt.ContainsKey(x) ? colCnt[x] : 0;
                        int cnt2 = colCnt.ContainsKey(x + d) ? colCnt[x + d] : 0;
                        int cnt3 = colCnt.ContainsKey(x - d) ? colCnt[x - d] : 0;
                        res += (colCnt.ContainsKey(x) ? colCnt[x] : 0) * (yCnt.ContainsKey(x + d) ? yCnt[x + d] : 0) * (colCnt.ContainsKey(x + d) ? colCnt[x + d] : 0);
                        res += (colCnt.ContainsKey(x) ? colCnt[x] : 0) * (yCnt.ContainsKey(x - d) ? yCnt[x - d] : 0) * (colCnt.ContainsKey(x - d) ? colCnt[x - d] : 0);
                    }
                }

                return res;
            }
        }
        
    }
}
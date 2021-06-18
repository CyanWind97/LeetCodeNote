using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 483
    /// title: 最小好进制
    /// problems: https://leetcode-cn.com/problems/smallest-good-base/
    /// date: 20210618
    /// </summary>
    public static class Solution483
    {
        // 参考解答 数学 等比数列
        public static string SmallestGoodBase(string n) {
            long x = long.Parse(n);
            int mMax = (int)Math.Floor(Math.Log(x) / Math.Log(2));
            

            for(int m = mMax; m > 1; m--){
                int k = (int) Math.Pow(x, 1.0 / m);
                long mul = 1, sum = 1;
                for(int i = 0; i < m; i++){
                    mul *= k;
                    sum += mul;
                }
                if(sum == x)
                    return k.ToString();
            }

            return (x - 1).ToString();
        }
    }
}
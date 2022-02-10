using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1447
    /// title: 最简分数
    /// problems: https://leetcode-cn.com/problems/simplified-fractions/
    /// date: 20220210
    /// </summary>
    public static class Solution1447
    {
        public static IList<string> SimplifiedFractions(int n) {
            if (n == 1)
                return new List<string>(0);
            
            string GetFraction(int a, int b) => @$"{a}/{b}";
            var map = new List<int>[n + 1];
            var result = new List<string>();

            for(int i = 2; i <= n; i++){
                result.Add(GetFraction(1, i));
                map[i] = new List<int>(){ 1 };
            }

            for(int i = 2; i <= n; i++){
                for(int j = 0; j < map[i].Count; j++){
                    while(map[i][j] + i <= n){
                        map[i][j] += i;
                        result.Add(GetFraction(i, map[i][j]));
                        map[map[i][j]].Add(i);
                    }
                    
                }
            }

            return result;
        }
    }
}
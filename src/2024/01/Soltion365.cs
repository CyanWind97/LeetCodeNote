using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 365
    /// title: 水壶问题
    /// problems: https://leetcode.cn/problems/water-and-jug-problem/description/?envType=daily-question&envId=2024-01-28
    /// date: 20240128
    /// </summary>
    public static class Soltion365
    {
        public static bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity) {
            if(jug1Capacity + jug2Capacity < targetCapacity)
                return false;
            
            if(jug1Capacity == 0 || jug2Capacity == 0)
                return targetCapacity == 0 || jug1Capacity + jug2Capacity == targetCapacity;
            
            int Gcd(int a, int b){
                if(a < b)
                    return Gcd(b, a);
                
                if(b == 0)
                    return a;
                
                return Gcd(b, a % b);
            }

            return targetCapacity % Gcd(jug1Capacity, jug2Capacity) == 0;
        }
    }
}
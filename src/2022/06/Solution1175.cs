using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1175
    /// title: 质数排列
    /// problems: https://leetcode.cn/problems/prime-arrangements/
    /// date: 20220630
    /// </summary>
    public static class Solution1175
    {
        public static int NumPrimeArrangements(int n) {
            const int MOD = 1000000007;

            bool IsPrime(int n){
                if(n == 1)
                    return false;
                
                for(int i = 2; i * i <= n; i++){
                    if(n % i == 0)
                        return false;
                }

                return true;
            }

            long Factorial(int n)
                => Enumerable.Range(1, n)
                        .Aggregate<int, long>(1, (i, result) => (result * i) % MOD);
            
            int primeCount = Enumerable.Range(1, n).Count(IsPrime);
            
            return (int)(Factorial(primeCount) * Factorial(n - primeCount) % MOD);
        }
    }
}
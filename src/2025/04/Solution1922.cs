using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1922
/// title: 统计好数字的数目
/// problems: https://leetcode.cn/problems/count-good-numbers
/// date: 20250413
/// </summary>
public static class Solution1922
{
    public static int CountGoodNumbers(long n) {
        const int MOD = 1_000_000_007;
        
        long ModPow(long baseValue, long exponent, int modulus) {
            if (modulus == 1) return 0;
            
            long result = 1;
            baseValue = baseValue % modulus;
            
            while (exponent > 0) {
                // 如果指数是奇数，乘以当前的基数
                if ((exponent & 1) == 1) {
                    result = (result * baseValue) % modulus;
                }
                
                // 指数除以2
                exponent >>= 1;
                
                // 基数平方
                baseValue = (baseValue * baseValue) % modulus;
            }
            
            return result;
        }
        
        // 计算偶数位的数量（位置 0, 2, 4, ...）
        long evenPositions = (n + 1) / 2; // 向上取整
        
        // 计算奇数位的数量（位置 1, 3, 5, ...）
        long oddPositions = n / 2; // 向下取整
        
        // 计算结果：5^evenPositions * 4^oddPositions
        // 使用快速幂算法计算，避免溢出
        long result = (ModPow(5, evenPositions, MOD) * ModPow(4, oddPositions, MOD)) % MOD;
        
        return (int)result;
    }
    
}

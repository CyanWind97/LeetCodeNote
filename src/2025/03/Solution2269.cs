using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2269
/// title: 找到一个数字的 K 美丽值
/// problems: https://leetcode.cn/problems/find-the-k-beauty-of-a-number
/// date: 20250310
/// </summary>
public class Solution2269
{
    public static int DivisorSubstrings(int num, int k) {
        long n = num;
        int count = 0;
        long divisor = (long)Math.Pow(10, k);
        
        // 一边取模一边整除，实现滑动窗口
        while (n >= Math.Pow(10, k - 1)) {
            // 获取当前窗口的k位数字
            long subNum = n % divisor;
            
            // 检查条件
            if (subNum != 0 && num % subNum == 0) {
                count++;
            }
            
            // 窗口右移
            n /= 10;
        }
        
        return count;
    }
}

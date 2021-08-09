using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 313
    /// title: 超级丑数
    /// problems: https://leetcode-cn.com/problems/super-ugly-number/
    /// date: 20210809
    /// </summary>
    public static class Solution313
    {
        // 参考解答 dp 多路归并？
        public static int NthSuperUglyNumber(int n, int[] primes)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;

            int length = primes.Length;
            int[] pointers = new int[length];
            Array.Fill(pointers, 1);

            for(int i = 2; i <= n; i++){
                int[] nums = new int[length];
                int min = int.MaxValue;
                for(int j = 0; j < length; j++){
                    nums[j] = dp[pointers[j]] * primes[j];
                    min = Math.Min(min, nums[j]);
                }

                dp[i] = min;

                for(int j = 0; j < length; j++){
                    if(nums[j] == min)
                        pointers[j]++;
                }
            }

            return dp[n];
        }


        // 77/83 
        // 报错示例
        // 700
        // [7,11,17,23,29,31,43,47,53,67,71,73,79,89,101,113,127,131,149,151,157,163,167,179,181,199,211,223,227,251]
        // 前500是对的，之后开始报错，为什么?
        public static int NthSuperUglyNumber_1(int n, int[] primes)
        {
            var result = new List<int>();
            result.Add(1);
            result.AddRange(primes);

            int BinarySearch(int start, int end, int target)
            {
                while (start <= end)
                {
                    int mid = (start + end) / 2;
                    
                    if(result[mid] == target)
                        return -1;
                    else if (result[mid] < target)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }

                return start;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int num = result[i] * result[j];
                    int index = BinarySearch(j + 1, Math.Min(n, result.Count) - 1, num);
                    if(index == -1)
                        continue;
                        
                    if(index > n)
                        break;

                    result.Insert(index, num);
                }
            }

            return result[n - 1];
        }
    }
}
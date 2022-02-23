using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1994
    /// title: 好子集的数目
    /// problems: https://leetcode-cn.com/problems/the-number-of-good-subsets/
    /// date: 20220222
    /// </summary>
    public static class Solution1994
    {

        // 参考解答 状态压缩
        public static int NumberOfGoodSubsets(int[] nums) {
            const int MOD = 1000000007;
            int[] filter = { 4, 8, 9, 12, 16, 18, 20, 24, 25, 27, 28 };
            int[] priems = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29};
            int pLength = priems.Length;
            
            int[] freq = new int[31];

            foreach(var num in nums){
                freq[num]++;
            }
            
            int fLength = 1 << pLength;
            int[] f = new int[fLength];
            f[0] = 1;

            for(int i = 0; i < freq[1]; i++){
                f[0] = f[0] * 2 % MOD;
            }

            for(int i = 2; i <= 30; i++){
                if(freq[i] == 0 || Array.BinarySearch(filter,i) >= 0)
                    continue;
                
                int subset = 0, x = i;
                for(int j = 0; j < pLength; j++){
                    int prime = priems[j];
                    if(x % prime == 0)
                        subset |= 1 << j;
                }
                
                for(int mask = fLength - 1; mask > 0; mask--){
                    if((mask & subset) == subset){
                        f[mask] = (int)((f[mask] + ((long)f[mask ^ subset]) * freq[i]) % MOD);
                    }
                }
            }

            int result = 0;
        
            for(int mask = 1; mask < fLength; ++mask){
                result = (result + f[mask]) % MOD;
            }

            return result;
        }
    }

}
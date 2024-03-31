using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1442
    /// title:  形成两个异或相等数组的三元组数目
    /// problems: https://leetcode-cn.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/
    /// date: 20210518
    /// </summary>

    public static class Solution1442
    {
        // 参考解答 前缀和 哈希表
        public static int CountTriplets(int[] arr) {
            int length = arr.Length;
            Dictionary<int, int> count  = new Dictionary<int, int>();
            Dictionary<int, int> total = new Dictionary<int, int>();
            int result = 0;
            int sum = 0;
            for(int k = 0; k < length; k++){
                int val = arr[k];
                if(count.ContainsKey(sum ^ val))
                    result += count[sum ^ val] * k - total[sum ^ val];
                
                
                if(!count.ContainsKey(sum))
                    count.Add(sum, 1);
                else
                    count[sum]++;
                
                if(!total.ContainsKey(sum))
                    total.Add(sum, k);
                else
                    total[sum] += k;
                
                sum ^= val;
            }

            return result;
        }
    }
}
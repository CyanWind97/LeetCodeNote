using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 523
    /// title: 连续的子数组和
    /// problems: https://leetcode-cn.com/problems/continuous-subarray-sum/
    /// date: 20210602
    /// </summary>
    public class Solution523
    {
        // 参考解答 前缀和 哈希表
        // 余数相同
        public static bool CheckSubarraySum(int[] nums, int k) {
            int length = nums.Length;
            if(length < 2)
                return false;

            int remainder = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(0, -1);
            for(int i = 0; i < length; i++){
                remainder = (nums[i] + remainder) % k;
                if(dic.ContainsKey(remainder)){
                    if(i - dic[remainder] > 1)
                        return true;
                }else{
                    dic.Add(remainder, i);
                }
                    
            }

            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 697
    /// title: 数组的度
    /// problems: https://leetcode-cn.com/problems/degree-of-an-array/
    /// date: 20210220
    /// </summary>
    public static class Solution697
    {
        public static int FindShortestSubArray(int[] nums) {
            int length = nums.Length;
            var dic = new Dictionary<int, int[]>();
            for(int i = 0; i < length; i++){
                int num = nums[i];
                if(!dic.ContainsKey(num)){
                    dic[num] = new int[]{1, i, i};
                }else{
                    dic[num][0]++;
                    dic[num][2] = i;
                }
            }
            
            var result = dic.Values.OrderBy(x => -x[0]).ThenBy(x => x[2] - x[1]).First();

            return  result[2] - result[1] + 1;
        }
    }
}
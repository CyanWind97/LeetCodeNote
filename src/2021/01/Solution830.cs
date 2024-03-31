using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 830
    /// title: 较大分组的位置
    /// problems: https://leetcode-cn.com/problems/positions-of-large-groups/
    /// date: 20210105
    /// </summary>
    public static class Solution830
    {
        public static IList<IList<int>> LargeGroupPositions(string s) {
            int length = s.Length;
            List<IList<int>> result = new List<IList<int>>();
            char[] chars = s.ToCharArray();
            int pre = 0;
            for(int i = 1; i < length; i++){
                if(chars[i] != chars[pre]){
                    if(i - pre >= 3)
                        result.Add(new int[]{pre, i - 1});
                    
                    pre = i;
                }
            }

            if(length - pre >= 3)
                result.Add(new int[]{pre, length - 1});
            
            return result;
        }
    }
}
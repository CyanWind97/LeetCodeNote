using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 45
    /// title:  全排列
    /// problems: https://leetcode.cn/problems/permutations/
    /// date: 20220512
    /// priority: 0039
    /// time: 00:07:03.01 timeout
    public static class CodeTop46
    {
        public static IList<IList<int>> Permute(int[] nums) {
            int length = nums.Length;
            
            var result = new List<IList<int>>();
            var perm = nums.ToList();

            void BackTrack(int first){
                if(first == length){
                    result.Add(new List<int>(perm));
                }

                for(int i = first; i < length; i++){
                    (perm[first], perm[i]) = (perm[i], perm[first]);
                    BackTrack(first + 1);
                    (perm[first], perm[i]) = (perm[i], perm[first]);
                }
            }

            BackTrack(0);


            return result;
        }
    }
}
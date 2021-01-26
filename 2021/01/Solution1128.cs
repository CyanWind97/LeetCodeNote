using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1128
    /// title: 等价多米诺骨牌对的数量
    /// problems: https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/
    /// date: 20210126
    /// </summary>
    public static class Solution1128
    {
         public static int NumEquivDominoPairs(int[][] dominoes) {
            int result = 0;
            int[] pairCount = new int[100];
            foreach(var pair in dominoes){
                int index = pair[0] < pair[1]
                        ? pair[0] * 10 + pair[1]
                        : pair[1] * 10 + pair[0];
                
                result += pairCount[index];
                pairCount[index]++;
            }

            return result;
        }
    }
}
using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 274
    /// title: H 指数
    /// problems: https://leetcode-cn.com/problems/h-index/
    /// date: 20210711
    /// </summary>

    public static partial class Solution274
    {
        public static int HIndex(int[] citations) {
            int length = citations.Length;
            int result = 0;
            Array.Sort(citations, (a,b) => b - a);
            for(int i = 0; i < length; i++){
                if(citations[i] >= i + 1)
                    result = i + 1;
                else
                    break;
            }

            return result;
        }

        // 参考解答 计数排序
        public static int HIndex_1(int[] citations){
            int n = citations.Length, tot = 0;
            int[] counter = new int[n + 1];
            for (int i = 0; i < n; i++) {
                if (citations[i] >= n) {
                    counter[n]++;
                } else {
                    counter[citations[i]]++;
                }
            }
            for (int i = n; i >= 0; i--) {
                tot += counter[i];
                if (tot >= i) {
                    return i;
                }
            }
            return 0;
        }
    }
}
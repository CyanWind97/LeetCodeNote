using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2039
    /// title: 统计最高分的节点数目
    /// problems: https://leetcode-cn.com/problems/count-nodes-with-the-highest-score/
    /// date: 20220311
    /// </summary>
    public static class Solution2049
    {
        public static int CountHighestScoreNodes(int[] parents) {
            int length = parents.Length;
            int[] left = new int[length];
            int[] right = new int[length];

            Array.Fill(left, -1);
            Array.Fill(right, -1);
            
            for(int i = 1; i < length; i++){
                if(left[parents[i]] == -1)
                    left[parents[i]] = i;
                else
                    right[parents[i]] = i;
            }

            int[] count = new int[length];
            
            int CalcCount(int num){
                if(left[num] != -1)
                    count[num] += CalcCount(left[num]);
                
                if(right[num] != -1)
                    count[num] += CalcCount(right[num]);
                
                return count[num] + 1;
            }

            CalcCount(0);

            long CalcScore(int num){
                long result = Math.Max(length - count[num] - 1, 1);

                if(left[num] != -1)
                    result *= count[left[num]] + 1;
                
                if(right[num] != -1)
                    result *= count[right[num]] + 1;
                
                return result;
            }

            long max = 0;
            int result = 0;

            for(int i = 0; i < length; i++){
                var score = CalcScore(i);
                if(score > max){
                    max = score;
                    result = 1;
                }else if(score == max){
                    result++;
                }
            }   

            return result;
        }
    }
}
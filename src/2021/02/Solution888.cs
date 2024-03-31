using System.Collections.Generic;
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 888
    /// title: 公平的糖果棒交换
    /// problems: https://leetcode-cn.com/problems/fair-candy-swap/
    /// date: 20210201
    /// </summary>
    public class Solution888
    {
        public static int[] FairCandySwap(int[] A, int[] B) {
            int lengthA = A.Length;
            int lengthB = B.Length;
            int delta = (A.Sum() - B.Sum()) / 2;
            Array.Sort(A);
            Array.Sort(B);

            int i = 0, j = 0;
            while(i < lengthA && j < lengthB){
                int cur = A[i] - B[j];
                if(cur > delta)
                    j++;
                else if(cur < delta)
                    i++;
                else
                    break;
            }

            return new int[]{A[i], B[j]};
        }

        // 参考解答 BFS
        public static int[] FairCandySwap_1(int[] A, int[] B) {
            int delta = (B.Sum() - A.Sum()) / 2;
            HashSet<int> set = new HashSet<int>(B);
            foreach(var x in A){
                if(set.Contains(x + delta))
                    return new int[]{x, x + delta};
            }
            
            return new int[]{};
        }
    }
}
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 989
    /// title: 数组形式的整数加法
    /// problems: https://leetcode-cn.com/problems/add-to-array-form-of-integer/
    /// date: 20210122
    /// </summary>
    public static class Solution989
    {
        public static IList<int> AddToArrayForm(int[] A, int K) {
            List<int> result = new List<int>();
            bool carry  = false;
            int i =  A.Length - 1;

            while(K != 0 || i >= 0){
                int sum = carry ? 1 : 0;
                if(K != 0){
                    sum +=  K % 10;
                    K /= 10;
                }
                
                if(i >= 0)
                    sum += A[i--];
                
                carry = sum > 9;
                if(carry)
                    sum %= 10;
                
                result.Add(sum);
            }

            if(carry)
                result.Add(1);

            result.Reverse();

            return result;
        }


        // 参考解答
         public static IList<int> AddToArrayForm_1(int[] A, int K) {
            bool isUp = false;
            int i = A.Length;
            while((K > 0 || isUp)){
                --i;
                var num = (i<0 ? 0: A[i])
                    + (K % 10) + (isUp?1:0);
                K /= 10;
                isUp = num > 9;
                num %= 10;
                if(i<0)
                    A = (new []{num}).Concat(A).ToArray();
                else
                    A[i] = num;
            }
            return A;
        }
    }
}
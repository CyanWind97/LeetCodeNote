using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 412
    /// title: Fizz Buzz
    /// problems: https://leetcode-cn.com/problems/fizz-buzz/
    /// date: 20211013
    /// </summary>
    public static class Solution412
    {
        public static IList<string> FizzBuzz(int n) {
            var result = new string[n];

            for(int i = 0; i < n; i++){
                result[i] = (i + 1).ToString();
            }

            for(int i = 2; i < n; i += 3){
                result[i] = "Fizz";
            }

            for(int i = 4; i <n; i += 5){
                result[i] = result[i] == "Fizz" ? "FizzBuzz" : "Buzz";
            }

            return result;
        }
    }
}
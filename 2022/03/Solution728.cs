using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 728
    /// title: 自除数
    /// problems: https://leetcode-cn.com/problems/self-dividing-numbers/
    /// date: 20220331
    /// </summary>
    public static class Solution728
    {
        public static IList<int> SelfDividingNumbers(int left, int right) {
            
            bool IsSelfDivid(int num){
                int tmp = num;
                while(tmp > 0){
                    int x = tmp % 10;

                    if(x == 0 || num % x != 0)
                        return false;
                    
                    tmp /= 10;
                }

                return true;
            }

            
            return Enumerable.Range(left, right - left + 1)
                            .Where(IsSelfDivid)
                            .ToList();
        }
    }
}
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 875
    /// title: 爱吃香蕉的珂珂
    /// problems: https://leetcode.cn/problems/koko-eating-bananas/
    /// date: 20220607
    /// </summary>
    public static class Solution875
    {
        public static int MinEatingSpeed(int[] piles, int h) {
            int length = piles.Length;
            int min = 1;
            int max = piles.Max();

            int CalcHour(int k)
                => piles.Aggregate(0, (sum, x) => sum + (x - 1) / k + 1);
            
            while(min < max){
                int mid = (max + min) / 2;
                int curH = CalcHour(mid);
                
                if(curH > h)
                    min = mid + 1;
                else
                    max = mid - 1;
            }

            return min;
        }
    }
}
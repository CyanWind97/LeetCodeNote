using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 881
    /// title: 救生艇
    /// problems: https://leetcode-cn.com/problems/boats-to-save-people/
    /// date: 20210826
    /// </summary>
    public static class Solution881
    {
        public static int NumRescueBoats(int[] people, int limit) {
            Array.Sort(people);
            
            int length = people.Length;
            int count = length;
            int left = 0;
            int right = length - 1;
            while(left < right){
                if(people[right] + people[left] <= limit){
                    count--;
                    left++;
                }

                right--;
            }

            return count;
        }
    }
}
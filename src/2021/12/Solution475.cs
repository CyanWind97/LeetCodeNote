using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 475
    /// title: 供暖器
    /// problems: https://leetcode-cn.com/problems/heaters/
    /// date: 20211220
    /// </summary>
    public static class Solution475
    {
        public static int FindRadius(int[] houses, int[] heaters) {
            int result = 0;
            
            int index = 0;
            int length = heaters.Length;
            int searchLength = length;
            Array.Sort(houses);
            Array.Sort(heaters);

            foreach(var house in houses){
                var search = Array.BinarySearch<int>(heaters, index, searchLength, house);

                if(search < 0){
                    search = ~search;
                    int diff = int.MaxValue;
                    if(search < length)
                        diff = Math.Min(diff, heaters[search] - house);
                    
                    if (search > 0)
                        diff = Math.Min(diff, house - heaters[search - 1]);

                    result = Math.Max(result, diff);
                    
                    index = Math.Max(search - 1, 0);
                }else{
                    index = search;
                }

                searchLength = length - index;
            }

            return result;
        }

        // 参考解答 双指针
        public static int FindRadius_1(int[] houses, int[] heaters) {
            Array.Sort(houses);
            Array.Sort(heaters);
            
            int result = 0;
            for (int i = 0, j = 0; i < houses.Length; i++) {
                int curDistance = Math.Abs(houses[i] - heaters[j]);
                while (j < heaters.Length - 1 && Math.Abs(houses[i] - heaters[j]) >= Math.Abs(houses[i] - heaters[j + 1])) {
                    j++;
                    curDistance = Math.Min(curDistance, Math.Abs(houses[i] - heaters[j]));
                }
                result = Math.Max(result, curDistance);
            }
            return result;
        }
    }
}
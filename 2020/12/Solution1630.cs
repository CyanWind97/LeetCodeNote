using System;
using System.Collections.Generic;
using System.Linq;


namespace LeetCodeNote
{
    /// <summary>
    /// no: 1630
    /// title: 等差子数组
    /// problems: https://leetcode-cn.com/problems/arithmetic-subarrays/
    /// date: 20201225
    /// </summary>
    public static class Solution1630
    {
        public static IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r) {
            int m = l.Length;
            bool[] result = new bool[m];
            
            for(int i = 0; i < m; i++) {
                int length = r[i] - l[i] + 1;
                bool flag = true;
                if(length > 2){
                    int[] temp = nums.Skip(l[i]).Take(length).ToArray();
                    Array.Sort(temp);
                    int diff = temp[1] - temp[0];
                    int j = 2;
                    while(j < length && temp[j] - temp[j-1] == diff){
                        j++;
                    }
                    if(j < length)
                        flag = false;
                }
                
                result[i] = flag;
            }

            return result.ToList();
        }

        // 优化
        public static IList<bool> CheckArithmeticSubarrays_1(int[] nums, int[] l, int[] r) {
            int m = l.Length;
            int n = nums.Length;
            bool[] result = new bool[m];
            
            for(int i = 0; i < m; i++) {
                int length = r[i] - l[i] + 1;
                int start = l[i];
                int end = r[i];
                if(length <= 2){
                    result[i] = true;
                    continue;
                }
                    
                int min1 = 0;
                int min2 = 0;
                if(nums[start] < nums[start + 1]){
                    min1 = nums[start];
                    min2 = nums[start + 1];
                }else{
                    min1 = nums[start + 1];
                    min2 = nums[start];
                }

                for(int j = start + 2; j <= end; j++){
                    if(nums[j] < min1) {
                        min2 = min1;
                        min1 = nums[j];
                    }else if(nums[j] < min2){
                        min2 = nums[j];
                    }
                }
                
                int diff = min2 - min1;
                if(diff == 0) {
                    result[i] = nums.Skip(start).Take(length).All(x => x == nums[start]);
                    continue;
                }

                int k = start;
                HashSet<int> tmp = new HashSet<int>(length);
                for(; k <= end; k++){
                    int sub = nums[k] - min1;
                    if(sub % diff != 0 || sub >= length * diff || !tmp.Add(sub))
                        break;
                }
                
                result[i]  = k > end;
            }

            return result.ToList();
        }

        // 参考解答
        public  static IList<bool> CheckArithmeticSubarrays_2(int[] nums, int[] l, int[] r) {
            bool GetSubArray(int[] source, int startIndex, int endIndex)
            {
                int minValue = Math.Min(source[startIndex], source[startIndex+1]);
                int minValue2 = Math.Max(source[startIndex], source[startIndex + 1]);
                int[] subArray = new int[endIndex - startIndex + 1];

                subArray[0] = source[startIndex];
                subArray[1] = source[startIndex + 1];

                for (int i = startIndex+2; i <= endIndex; i++)
                {
                    int curValue = source[i];
                    subArray[i - startIndex] = curValue;
                    if(curValue >= minValue2)
                    {
                        continue;
                    }
                    else if(curValue >= minValue && curValue <= minValue2)
                    {
                        minValue2 = curValue;
                    }
                    else
                    {
                        minValue2 = minValue;
                        minValue = curValue;
                    }
                }

                int distance = minValue2 - minValue;

                if(distance == 0)
                {
                    return subArray.All(i => i == minValue) ;
                }
                else
                {
                    for (int i = 0; i < subArray.Length; i++)
                    {
                        if((subArray[i] - minValue) % distance != 0)
                        {
                            return false;
                        }

                        for (int j = i + 1; j < subArray.Length; j++)
                        {
                            if ((subArray[j] - minValue) % distance != 0)
                            {
                                return false;
                            }

                            if (subArray[i] > subArray[j])
                            {
                                int temp = subArray[i];
                                subArray[i] = subArray[j];
                                subArray[j] = temp;
                            }
                        }

                        if (i > 0)
                        {
                            if ((subArray[i] - subArray[i - 1]) != distance)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            bool[] result = new bool[l.Length];

            for (int i = 0; i < l.Length; i++)
            {
                result[i] = GetSubArray(nums, l[i], r[i]);
            }

            return result;
        }
    }
}
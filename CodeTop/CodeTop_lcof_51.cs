using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 51
    /// title:  数组中的逆序对
    /// problems: https://leetcode.cn/problems/shu-zu-zhong-de-ni-xu-dui-lcof/
    /// date: 20220514
    /// type: 剑指Offer lcof
    /// priority: 0049
    /// time: 00:31:29.54 timeout
    /// </summary>
    public class CodeTop_lcof_51
    {

        public static int ReversePairs(int[] nums) {
            int count = 0;
            var sortedNums = new List<int>();
            
            foreach(var num in nums){
                var index = sortedNums.BinarySearch(num);
                if(index < 0)
                    index = ~index;
                else
                    while(index < sortedNums.Count && sortedNums[index] == num){
                        index++;
                    }
                
                count += sortedNums.Count - index;
                sortedNums.Insert(index, num);
            }

            return count;
        }

        public static int ReversePairs_1(int[] nums){
            int length = nums.Length;
            if(length < 2)
                return 0;
            
            var tmp = new int[length];

            int ReversePairs(int left, int right){
                if(left == right)
                    return 0;
                
                int mid = left + (right - left) / 2;
                int leftPairs = ReversePairs(left,  mid);
                int rightPairs = ReversePairs(mid + 1, right);
                if(nums[mid] <= nums[mid + 1])
                    return leftPairs + rightPairs;
                

                int MergeAndCount(){
                    for(int k = left; k <= right; k++){
                        tmp[k] = nums[k];
                    }

                    int i = left;
                    int j = mid + 1;

                    int count = 0;
                    for(int k = left; k <= right; k++){
                        if(i == mid + 1){
                            nums[k] = tmp[j];
                            j++;
                        }else if(j == right + 1){
                            nums[k] = tmp[i];
                            i++;
                        }else if(tmp[i] <= tmp[j]){
                            nums[k] = tmp[i];
                            i++;
                        }else{
                            nums[k] = tmp[j];
                            j++;
                            count += (mid - i + 1);
                        }
                    }

                    return count;
                }
                
                int crossPairs = MergeAndCount();

                return leftPairs + rightPairs + crossPairs;
            }

            return ReversePairs(0, length - 1);
        }
    }
}
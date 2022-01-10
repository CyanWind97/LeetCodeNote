using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 306
    /// title: 累加数
    /// problems: https://leetcode-cn.com/problems/additive-number/
    /// date: 20220110
    /// </summary>
    public static class Solution396
    {
        public static bool IsAdditiveNumber(string num) {
            var nums = num.Select(c => c - '0').ToList();
            
            if(nums.Count < 3)
                return false;


            bool IsValid(int l1, int l2){
                int first = 0;
                int l3 = Math.Max(l1, l2);

                while(first + l1 + l2 + l3 <= nums.Count){
                    if(l2 > 1 && nums[first + l1] == 0)
                        return false;

                    int carry = 0;
                    var tmp = new int[l3];

                    for(int i = l1 - 1, j = l2 - 1, k = l3 - 1; k >= 0; k--){
                        if(i >= 0){
                            tmp[k] += nums[first + i];
                            i--;
                        }

                        if(j >= 0){
                            tmp[k] += nums[first + l1 + j];
                            j--;
                        }

                        tmp[k] += carry;
                        if(tmp[k] >= 10){
                            tmp[k] -= 10;
                            carry = 1;
                        }else{
                            carry = 0;
                        }
                    }

                    int third = first + l1 + l2;
                    if(carry == 1)
                        if (nums[third] != 1)
                            return false;
                        else
                            l3++;
                    
                    for(int i = 0; i < l3 - carry; i++){
                        if(tmp[i] != nums[third + carry + i])
                            return false;
                    }

                    first += l1;
                    l1 = l2;
                    l2 = l3;
                }

                return first + l1 + l2 == nums.Count;
            }

            int maxL1 = nums[0] == 0 ? 1 : (nums.Count - 1) / 2;

            for(int l1 = 1; l1 <= maxL1; l1++){
                int maxL2 = (nums.Count - l1) / 2;

                for(int l2 = 1; l2 <= maxL2; l2++){
                    if(IsValid(l1, l2))
                        return true;
                }
            }

            return false;
        }
    }
}
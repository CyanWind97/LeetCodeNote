using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.11
    /// title: 17.11. 单词距离
    /// problems: https://leetcode.cn/problems/find-closest-lcci/
    /// date: 20220527
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_11
    {
        public static int FindClosest(string[] words, string word1, string word2) {
            int length = words.Length;  
            bool find1 = false;
            bool find2 = false;

            int left = 0;
            int right = 0;
            int min = length + 1;

            while(right < length){
                while((!find1 || !find2) && right < length){
                    if(words[right] == word1){
                        find1 = true;
                        if(!find2)
                            left = right;
                    }else if(words[right] == word2){
                        find2 = true;
                        if(!find1)
                            left = right;
                            
                    }

                    right++;
                }

                if(find1 && find2){
                    min = Math.Min(min, right - left - 1);
                    find1 = words[right - 1] == word1;
                    find2 = words[right - 1] == word2;
                    left = right - 1;
                }else{
                    break;
                }
            }

            return min;
        }

        // 参考解答 维护index更合理
        public static int FindClosest_1(string[] words, string word1, string word2) {
            int length = words.Length;
            int result = length;
            int index1 = -1, index2 = -1;
            for (int i = 0; i < length; i++) {
                string word = words[i];
                if (word == word1) 
                    index1 = i;
                else if (word == word2) 
                    index2 = i;
                
                if (index1 >= 0 && index2 >= 0) 
                    result = Math.Min(result, Math.Abs(index1 - index2));
            }
            
            return result;
        }

    }
}
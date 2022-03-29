using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2024
    /// title: 考试的最大困扰度
    /// problems: https://leetcode-cn.com/problems/maximize-the-confusion-of-an-exam/
    /// date: 20220329
    /// </summary>
    public static class Solution2024
    {
        // 参考解答 滑动窗口
        public static int MaxConsecutiveAnswers(string answerKey, int k) {
            var chars = answerKey.ToCharArray();
            var length =  chars.Length;
            var tCount = chars.Count(c => c == 'T');
            if(tCount <= k || tCount + k >= length)
                return length;

            int MaxConsecutiveChar(char ch) {
                int result = 0;
                for (int left = 0, right = 0, sum = 0; right < length; right++) {
                    sum += chars[right] != ch ? 1 : 0;
                    while (sum > k) {
                        sum -= chars[left++] != ch ? 1 : 0;
                    }
                    result = Math.Max(result, right - left + 1);
                }

                return result;
            }

            return Math.Max(MaxConsecutiveChar('T'), MaxConsecutiveChar('F'));
        }

        // 参考解答 二分查找 + 浅醉和
        public static int MaxConsecutiveAnswers_1(string answerKey, int k) {
            var length = answerKey.Length;
            var result = 0;
            var preSum = new int[length + 1];

            void CalcResult(){
                for(int i = 1; i <= length; i++){
                    if(i == length || preSum[i] < preSum[i + 1]){
                        int index = Array.BinarySearch(preSum, 0, i + 1, preSum[i] - k);
                        if(index < 0)
                            index = ~index;
                        
                        while(index > 0 && preSum[index] == preSum[index - 1])
                            index--;

                        result = Math.Max(result, i - index);
                    }
                }
            }

            //求T的前缀和
            for(int i  = 1; i <= length; i++){
                preSum[i] = answerKey[i - 1] == 'T' ? preSum[i - 1] + 1 : preSum[i - 1];
            }
            
            CalcResult();

            // 改为F的前缀和
            for(int i = 1; i <= length; i++){
                preSum[i] = i - preSum[i];
            }

            CalcResult();

            return result;
        }
    }
}
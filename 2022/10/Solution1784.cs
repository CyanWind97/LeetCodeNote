namespace LeetCodeNote
{
    /// <summary>
    /// no: 1784
    /// title: 检查二进制字符串字段
    /// problems: https://leetcode.cn/problems/check-if-binary-string-has-at-most-one-segment-of-ones/
    /// date: 20221003
    /// </summary>
    public static class Solution1784
    {
        public static bool CheckOnesSegment(string s) {
            var prev = '1';
            foreach(var c in s){
                if(c == '1' && prev == '0')
                    return false;
                
                prev = c;
            }

            return true;
        }
        
        // 参考解答
        // 题目说明不含前导0
        // Contains 为什么速度快呢？
        public static bool CheckOnesSegment_1(string s) {
            return !s.Contains("01");
        }
    
                    
    }
}
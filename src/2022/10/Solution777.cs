namespace LeetCodeNote
{
    /// <summary>
    /// no: 777
    /// title: 在LR字符串中交换相邻字符
    /// problems: https://leetcode.cn/problems/swap-adjacent-in-lr-string/
    /// date: 20221002
    /// </summary>
    public static class Solution777
    {
        // 参考解答
        public static bool CanTransform(string start, string end) {
            int length = start.Length;
            int i = 0;
            int j = 0;
            while (i < length && j < length) {
                while (i < length && start[i] == 'X') {
                    i++;
                }
                while (j < length && end[j] == 'X') {
                    j++;
                }

                if (i < length && j < length) {
                    if (start[i] != end[j])
                        return false;
                    
                    char c = start[i];
                    if ((c == 'L' && i < j) || (c == 'R' && i > j)) 
                        return false;
                    
                    i++;
                    j++;
                }
            }

            while (i < length) {
                if (start[i] != 'X') 
                    return false;
                
                i++;
            }

            while (j < length) {
                if (end[j] != 'X') 
                    return false;
                
                j++;
            }

            return true;
        }
    }
}
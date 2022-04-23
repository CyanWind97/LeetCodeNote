namespace LeetCodeNote
{
    /// <summary>
    /// no: 821
    /// title: 字符的最短距离
    /// problems: https://leetcode-cn.com/problems/shortest-distance-to-a-character/
    /// date: 20220419
    /// </summary>

    public static class Solution821
    {
        public static int[] ShortestToChar(string s, char c) {
            var length = s.Length;
            var result = new int[length];
            
            int i = 0;
            while(i < length){
                if(s[i] != c){
                    result[i] = length - i - 1;
                    i++;
                    continue;
                }
                
                result[i] = 0;
                for(int j = 1;j <= i && result[i - j] > j; j++){
                    result[i - j] = j; 
                }

                int cur =i;
                i++;
                for(; i < length && s[i] != c; i++){
                    result[i] = i - cur;
                }
            }
            
            return result;
        }
    }
}
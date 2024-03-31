namespace LeetCodeNote
{
    /// <summary>
    /// no: 393
    /// title: UTF-8 编码验证
    /// problems: https://leetcode-cn.com/problems/utf-8-validation/
    /// date: 20220313
    /// </summary>
    public static class Solution393
    {
        
        public static bool ValidUtf8(int[] data) {
            int code = 1 << 7;
            int count = 0;
            
            foreach(var num in data){
                if((num & code) == 0)
                    if(count > 0)
                        return false;
                    else
                        continue;
                
                if(count > 0){
                    count--;
                    continue;
                }

                var tmp = num << 1;
                while((tmp & code) != 0){
                    count++;
                    tmp <<= 1;
                }

                if(count == 0 || count >= 4)
                    return false;
            }

            return count == 0;
        }
    }
}
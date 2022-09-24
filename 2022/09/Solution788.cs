namespace LeetCodeNote
{
    /// <summary>
    /// no: 788
    /// title: 旋转数字
    /// problems: https://leetcode.cn/problems/rotated-digits/
    /// date: 20220925
    /// </summary>
    public static class Solution788
    {
        // 参考解答 
        // 枚举
        public static int RotatedDigits(int n) {
            int[] check = {0, 0 , 1, -1, -1, 1, 1, -1, 0, 1};
            
            int result = 0;
            for(int i = 1; i <= n; i++){
                var num = i.ToString();
                bool valid = true;
                bool diff = false;
                foreach(var c in num){
                    if(check[c - '0'] == -1)
                        valid = false;
                    else if(check[c - '0'] == 1)
                        diff = true;
                }

                if(valid && diff)
                    result++;
            }

            return result;
        }
    }
}
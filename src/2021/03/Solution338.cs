namespace LeetCodeNote
{
    /// <summary>
    /// no: 338
    /// title: 比特位计数
    /// problems: https://leetcode-cn.com/problems/counting-bits/
    /// date: 20210303
    /// </summary>
    public static class Solution338
    {
        public static int[] CountBits(int num) {
            int[] result = new int[num + 1];

            result[0] = 0;
            int cur = 0;
            int index = 1;
            while(index <= num){
                result[index++] = result[cur++] + 1;
                if(index == 2 * cur){
                    cur = 0;
                }
            }

            return result;
        }

        // 参考解答
        public static int[] CountBits_1(int num) {
            int[] bits = new int[num + 1];

            for(int i = 1; i <= num; i++){
                bits[i] = bits[i & (i - 1)] + 1;
            }

            return bits;
        }
    }
}
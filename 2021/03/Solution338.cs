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
            int max = 1;
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
    }
}
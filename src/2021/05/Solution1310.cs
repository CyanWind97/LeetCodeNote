namespace LeetCodeNote
{
    /// <summary>
    /// no: 872
    /// title:  叶子相似的树
    /// problems: https://leetcode-cn.com/problems/leaf-similar-trees/
    /// date: 20210510
    /// </summary>
    public static class Solution1310
    {
        public static int[] XorQueries(int[] arr, int[][] queries) {
            int length = arr.Length;
            int[] preffix = new int[length + 1];
            preffix[0] = 0;
            for(int i = 0; i < length; i++){
                preffix[i + 1] = preffix[i] ^ arr[i]; 
            }

            int qLength = queries.Length;
            int[] result = new int[qLength];
            for(int i = 0; i < qLength; i++)
            {
                result[i] = preffix[queries[i][0]] ^ preffix[queries[i][1] + 1];
            }

            return result;
        }
    }
}
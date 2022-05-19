namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 96
    /// title:  不同的二叉搜索树
    /// problems: https://leetcode.cn/problems/unique-binary-search-trees/
    /// date: 20220519
    /// priority: 0086
    /// time: 00:05:04.71 timeout
    /// </summary>
    public static class CodeTop96
    {   
        // 参考解答 卡塔兰数
        public static int NumTrees(int n) {
            long C = 1;
            for (int i = 0; i < n; ++i) {
                C = C * 2 * (2 * i + 1) / (i + 2);
            }

            return (int)C;
        }

        public static int NumTrees_1(int n){
            int[] G = new int[n + 1];
            G[0] = 1;
            G[1] = 1;

            for(int i = 2; i <= n; i++){
                for(int j = 1; j <= i; j++){
                    G[i] += G[j - 1] * G[i - j];
                }
            }

            return G[n];
        }
    }
}
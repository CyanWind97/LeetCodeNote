namespace LeetCodeNote
{
    /// <summary>
    /// no: 427
    /// title: 建立四叉树
    /// problems: https://leetcode-cn.com/problems/construct-quad-tree/
    /// date: 20220429
    /// </summary>
    public static class Solution427
    {
        public class Node {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node() {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }
            
            public Node(bool _val, bool _isLeaf) {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }
            
            public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }

        public static Node Construct(int[][] grid) {
            int n = grid.Length;

            Node Construct(int r, int c,  int size){
                var val = grid[r][c] == 1;
                var isLeaf = true;

                if(size == 1)
                    return new Node(val, true);
                
                var subSize = size / 2;
                var topLeft = Construct(r, c, subSize);
                isLeaf = isLeaf && topLeft.isLeaf && val == topLeft.val;
                var topRight = Construct(r, c + subSize, subSize);
                isLeaf = isLeaf && topRight.isLeaf && val == topRight.val;
                var bottomLeft = Construct(r + subSize, c, subSize);
                isLeaf = isLeaf && bottomLeft.isLeaf && val == bottomLeft.val;
                var bottomRight = Construct(r + subSize, c + subSize, subSize);
                isLeaf = isLeaf && bottomRight.isLeaf && val == bottomRight.val;
                
                if(isLeaf)
                    return new Node(val, true);
                else
                    return new Node(val, false, topLeft, topRight, bottomLeft, bottomRight);
            }


            return Construct(0, 0, n);
        }

        // 参考解答 二维前缀和
        public static Node Construct_1(int[][] grid) {
            int n = grid.Length;
            var pre = new int[n + 1, n + 1];
            
            for(int i = 1; i <= n; i++){
                for(int j = 1; j <= n; j++){
                    pre[i, j] = pre[i - 1, j]  + pre[i, j - 1] - pre[i - 1, j - 1] + grid[i - 1][j - 1];
                }
            }
            
            int GetSum(int r, int c, int size)
                => pre[r + size, c + size] - pre[r + size, c] - pre[r, c + size] + pre[r, c];

            Node Construct(int r, int c, int size){
                int sum = GetSum(r, c, size);
                if(sum == 0)
                    return new Node(false, true);
                else if(sum == size * size)
                    return new Node(true, true);
                
                return new Node(
                    true,
                    false,
                    Construct(r, c, size / 2),
                    Construct(r, c + size / 2, size / 2),
                    Construct(r + size / 2, c, size / 2),
                    Construct(r + size / 2, c + size / 2, size / 2)
                );
            }

            return Construct(0, 0, n);
        }
    }
}
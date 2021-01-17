namespace LeetCodeNote
{
    /// <summary>
    /// no: 1232
    /// title: 缀点成线
    /// problems: https://leetcode-cn.com/problems/check-if-it-is-a-straight-line/
    /// date: 20210117
    /// </summary>
    public static class Solution1232
    {
        public static bool CheckStraightLine(int[][] coordinates) {
            int length = coordinates.Length;
            int x0 = coordinates[0][0];
            int y0 = coordinates[0][1];
            double k = (double)(coordinates[1][1] - y0)/ (double)(coordinates[1][0] - x0);

            for(int i = 2; i < length; i++){
                double ki = (double)(coordinates[i][1] - y0)/(double)(coordinates[i][0] - x0);
                if(!(double.IsInfinity(ki) && double.IsInfinity(k)) && ki != k)
                    return false;
            }

            return true;
        }

        // 参考解答 直线方程 Ax + By = 0;
        public static bool CheckStraightLine_1(int[][] coordinates) {
            int length = coordinates.Length;
            int x0 = coordinates[0][0];
            int y0 = coordinates[0][1];
            int A = coordinates[1][1] - y0;
            int B = coordinates[1][0] - x0;

            for(int i = 2; i < length; i++){
                if(A * (coordinates[i][0] - x0) != B * (coordinates[i][1] - y0))
                    return false;
            }

            return true;
        }

        // 参考解答 老老实实判断横坐标相等最快
        public static bool CheckStraightLine_2(int[][] coordinates) {
            int length =coordinates.Length;

            int X0 = coordinates[0][0];
            int Y0 = coordinates[0][1];
            int X1 = coordinates[1][0];
            int Y1 = coordinates[1][1];

            if(X1 - X0 == 0)
            {
                for(int i= 2;i < length;i++)
                {
                    if(coordinates[i][0] != X0)
                        return false;
                }
            }else{
                double k = (double)(Y1 - Y0)/(double)(X1 - X0);
                for(int i= 2; i < length; i++)
                {
                    if((double)(coordinates[i][1] - Y0)/(double)(coordinates[i][0] - X0) != k)
                        return false;
                }
            }
            
            return true;
        }
    }
}
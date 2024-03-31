namespace LeetCodeNote
{

    /// <summary>
    /// no: 780
    /// title: 到达终点
    /// problems: https://leetcode-cn.com/problems/reaching-points/
    /// date: 20220409
    /// </summary>
    public static class Solution780
    {
        public static bool ReachingPoints(int sx, int sy, int tx, int ty) {
            while (tx > sx && ty > sy && tx != ty) {
                if (tx > ty) 
                    tx %= ty;
                else
                    ty %= tx;
            }


            if (tx == sx && ty == sy)
                return true;
            else if (tx == sx)
                return ty > sy && (ty - sy) % tx == 0;
            else if (ty == sy)
                return tx > sx && (tx - sx) % ty == 0;
            else
                return false;
        }
    }
}
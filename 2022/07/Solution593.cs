namespace LeetCodeNote
{
    /// <summary>
    /// no: 593
    /// title:  有效的正方形
    /// problems: https://leetcode.cn/problems/valid-square/
    /// date: 20220729
    /// </summary>
    public static class Solution593
    {
        public static bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
            bool Help(int[] p1, int[] p2, int[] p3, int[] p4) {
                int[] v1 = {p1[0] - p2[0], p1[1] - p2[1]};
                int[] v2 = {p3[0] - p4[0], p3[1] - p4[1]};
                
                return CheckMidPoint(p1, p2, p3, p4) && CheckLength(v1, v2) && CalCos(v1, v2);
            }

            bool CheckLength(int[] v1, int[] v2) 
                => (v1[0] * v1[0] + v1[1] * v1[1]) == (v2[0] * v2[0] + v2[1] * v2[1]);
            

            bool CheckMidPoint(int[] p1, int[] p2, int[] p3, int[] p4)
                => (p1[0] + p2[0]) == (p3[0] + p4[0]) && (p1[1] + p2[1]) == (p3[1] + p4[1]);
            

            bool CalCos(int[] v1, int[] v2) 
                => (v1[0] * v2[0] + v1[1] * v2[1]) == 0;

            if (p1[0] == p2[0] && p1[1] == p2[1]) 
                return false;
            
            if (Help(p1, p2, p3, p4)) 
                return true;
            
            if (p1[0] == p3[0] && p1[1] == p3[1]) 
                return false;
            
            if (Help(p1, p3, p2, p4)) 
                return true;
            
            if (p1[0] == p4[0] && p1[1] == p4[1]) 
                return false;
            
            if (Help(p1, p4, p2, p3)) 
                return true;
            
            return false;
        }
    }
}
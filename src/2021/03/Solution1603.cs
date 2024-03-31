namespace LeetCodeNote
{
    /// <summary>
    /// no: 1603
    /// title: 设计停车系统
    /// problems: https://leetcode-cn.com/problems/design-parking-system/
    /// date: 20210319
    /// </summary>
    public static class Solution1603
    {
        public class ParkingSystem {
            
            private int[] spaces;

            public ParkingSystem(int big, int medium, int small) {
                spaces = new int[3];
                spaces[0] = big;
                spaces[1] = medium;
                spaces[2] = small;
            }
            
            public bool AddCar(int carType) {
                if(spaces[carType - 1] == 0)
                    return false;
                
                spaces[carType - 1]--;
                return true;
            }
        }

    }
}
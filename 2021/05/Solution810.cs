namespace LeetCodeNote
{
    /// <summary>
    /// no: 810
    /// title:  黑板异或游戏
    /// problems: https://leetcode-cn.com/problems/chalkboard-xor-game/
    /// date: 20210522
    /// </summary>
    public static class Solution810
    {
        // 参考解答 数学推理
        public static bool XorGame(int[] nums) {
            if(nums.Length % 2 == 0)
                return true;    
            
            int xor = 0;
            foreach(int num in nums){
                xor ^= num;
            }

            return xor  == 0;
        }
    }
}
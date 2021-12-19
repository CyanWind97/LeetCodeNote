namespace LeetCodeNote
{
    /// <summary>
    /// no: 1518
    /// title:  换酒问题
    /// problems: https://leetcode-cn.com/problems/water-bottles/
    /// date: 20211217
    /// </summary>
    public static class Solution1518
    {
        public static int NumWaterBottles(int numBottles, int numExchange) {
            var result = 0;
            var x = numBottles;
            var y = 0;
            
            while(x > 0){
                result += x;
                y += x;
                x = y / numExchange;
                y -= x * numExchange;
            }

            return result;
        }


        /// <summary>
        /// 参考解答
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public static int NumWaterBottles_1(int numBottles, int numExchange) 
            => numBottles >= numExchange ? (numBottles - numExchange) / (numExchange - 1) + 1 + numBottles : numBottles;
    }
}
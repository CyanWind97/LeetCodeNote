namespace LeetCodeNote
{
    /// <summary>
    /// no: 605
    /// title: 种花问题
    /// problems: https://leetcode-cn.com/problems/can-place-flowers/
    /// date: 20210101
    /// </summary>
    public static class Solution605
    {
        public static bool CanPlaceFlowers(int[] flowerbed, int n) {
            int length = flowerbed.Length;
            int interval = 1;
            for(int i = 0; i < length && n > 0; i++){
                if(flowerbed[i] == 0){
                    interval++;
                }else{
                    if(interval > 2){
                        n -= (interval - 1) / 2;
                    }
                    interval = 0;
                }
            }

            if(interval >= 2)
                n -= interval / 2;

            return n > 0 ? false : true;
        }

        // 参考解答 跳格法
        public static bool CanPlaceFlowers_1(int[] flowerbed, int n) {
            int length = flowerbed.Length;
            for(int i = 0; i < length && n > 0; i += 2){
                if(flowerbed[i] == 0){
                    if(i == length - 1 || flowerbed[i + 1] == 0){
                        n--;
                    }else{
                        i++;
                    }
                }
            }

            return  n <= 0;
        }
    }
}
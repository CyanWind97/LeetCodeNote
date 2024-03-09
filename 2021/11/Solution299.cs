namespace LeetCodeNote
{
    /// <summary>
    /// no: 299
    /// title:  猜数字游戏
    /// problems: https://leetcode-cn.com/problems/bulls-and-cows/
    /// date: 20211108
    /// </summary>
    public static partial class Solution299
    {
        public static string GetHint(string secret, string guess) {
            int aCount = 0;
            int bCount = 0;

            int[] counts = new int[10];
            
            int length = secret.Length;
            for(int i = 0; i < length; i++){
                if (secret[i] == guess[i]){
                    aCount++;
                    continue;
                }

                if (counts[secret[i] - '0'] < 0)
                    bCount++;
                
                counts[secret[i] - '0']++;

                if (counts[guess[i] - '0'] > 0)
                    bCount++;
                
                counts[guess[i] - '0']--;
            }

            return $"{aCount}A{bCount}B";
        }
    }
}
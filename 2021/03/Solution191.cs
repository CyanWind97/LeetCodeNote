namespace LeetCodeNote
{
    public static class Solution191
    {
        public static int HammingWeight(uint n) {
            int result = 0;
            while(n != 0){
                n &= n - 1;
                result++;
            }

            return result;
        }
    }
}
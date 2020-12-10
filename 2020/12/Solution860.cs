namespace LeetCodeNote
{
    /// <summary>
    /// no: 860
    /// title: ƒ˚√ ÀÆ’“¡„
    /// problems: https://leetcode-cn.com/problems/lemonade-change/
    /// date: 20201210
    /// </summary>
    public static class Solution860
    {
        public static bool LemonadeChange(int[] bills) {
            int count1 = 0;
            int count2 = 0;

            foreach(int bill in bills) {
                if(bill == 5){
                    count1++;
                }else if(bill == 10) {
                    if(count1 == 0)
                        return false;
                    
                    count1--;
                    count2++;
                }else{
                    if(count2 > 0 && count1 > 0) {
                        count1--;
                        count2--;
                    }else if(count1 >= 3) {
                        count1 -= 3;
                    }else{
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 2038
    /// title: 如果相邻两个颜色均相同则删除当前颜色
    /// problems: https://leetcode-cn.com/problems/remove-colored-pieces-if-both-neighbors-are-the-same-color/
    /// date: 20220322
    /// </summary>
    public static class Solution2038
    {
        public static bool WinnerOfGame(string colors) {
            int[] steps = new int[2];
        
            char pre = 'C';
            int count = 0;
            
            foreach(var color in colors){
                if(pre == color){
                    count++;
                }else{
                    if(count >= 3)
                        steps[pre - 'A'] += count - 2;
                    
                    pre = color;
                    count = 1;
                }
            }
            
            if(count >= 3)
                steps[pre - 'A'] += count - 2;

            return steps[0] > steps[1];
        }
    }
}
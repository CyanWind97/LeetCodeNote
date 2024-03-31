using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1138
    /// title: 字母板上的路径
    /// problems: https://leetcode.cn/problems/alphabet-board-path/
    /// date: 20230212
    /// </summary>
    public static class Solution1138
    {
        public static string AlphabetBoardPath(string target) {
            var result = new StringBuilder();
            var curR = 0;
            var curC = 0;

            void AddChar(int count, char c){
                for(int i = 0; i < count; i++){
                    result.Append(c);
                }
            }

            foreach(var c in target){
                var nextR = (c - 'a') / 5;
                var nextC = (c - 'a') % 5;

                if(nextR < curR)
                    AddChar(curR - nextR, 'U');

                if(nextC < curC)
                    AddChar(curC - nextC, 'L');

                if(nextR > curR)
                    AddChar(nextR - curR, 'D');
                
                if(nextC > curC)
                    AddChar(nextC - curC, 'R');
                
                result.Append('!');
                curR = nextR;
                curC = nextC;
            }

            return result.ToString();
        }
    }
}
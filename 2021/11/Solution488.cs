using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 488
    /// title: 祖玛游戏
    /// problems: https://leetcode-cn.com/problems/zuma-game/
    /// date: 20211109
    /// </summary>
    public static class Solution488
    {
        // 参考解答 剪纸 回溯
        public static int FindMinStep(string board, string hand) {
            const int INF = int.MaxValue / 2;
            var map = new Dictionary<string,Dictionary<string,int>>();
            int m = hand.Length;
            var arr = hand.ToCharArray();
            Array.Sort(arr);
            hand=new string(arr);

            var ans = DFS(board,hand);
            return ans>=INF ? -1 : ans;

            string Process(string input){
                if(input.Length<=2) return input;
                var sb = new StringBuilder();
                var c=input[0];
                int cnt = 1;
                for(int i=1;i<input.Length;i++)
                {
                    if(input[i]==c)
                    {
                        cnt++;
                    }
                    else
                    {
                        if(cnt<3)
                        {
                            sb.Append(c,cnt);
                        }
                        c=input[i];
                        cnt=1;
                    }
                }
                if(cnt<3) sb.Append(c,cnt);
                var output=sb.ToString();
                if(output.Length<input.Length) return Process(output);
                else return output;
            }

            int DFS(string board,string hand){
                if(board=="") return 0;
                if(hand=="") return INF;
                if(map.ContainsKey(board)){
                    if(map[board].ContainsKey(hand)) return map[board][hand];
                    else map[board][hand]=INF;
                }
                else{
                    map[board] = new Dictionary<string,int>();
                    map[board][hand]=INF;
                }
                int ans = INF;
                for(int i=0;i<hand.Length;i++)
                {
                    //剪枝，如果前面已经发了一样的球，那可以跳过，因为发同样的球形成的nb和nh都是一样的
                    if(i>0&&hand[i]==hand[i-1]) continue;
                    var nh = hand.Remove(i,1);
                    var ball=hand[i].ToString();
                    for(int j=0;j<=board.Length;j++)
                    {
                        //剪枝，如果插入的球和当前球一样，则不插入（只能插入同类球之后）
                        if(j<board.Length&&board[j]==ball[0]) continue;
                        var nb=board.Insert(j,ball);
                        nb = Process(nb);
                        ans=Math.Min(ans,DFS(nb,nh));
                    }
                }
                ans++;
                map[board][hand]=ans;
                return ans;
            }
        }
    }
}
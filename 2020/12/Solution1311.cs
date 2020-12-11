using System.Net.Mime;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1311
    /// title: 获取你好友已观看的视频
    /// problems: https://leetcode-cn.com/problems/get-watched-videos-by-your-friends/
    /// date: 20201211
    /// </summary>
    public static class Solution1311
    {
        public static IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level) {
            HashSet<int> friendsSet = new HashSet<int>();
            HashSet<int> preSet = new HashSet<int>();
            friendsSet.Add(id);
            preSet.Add(id);
            while(level > 0) {
                HashSet<int> tmpSet = new HashSet<int>();
                foreach(int i in friendsSet){
                    tmpSet.UnionWith(friends[i]);
                }
                tmpSet.ExceptWith(preSet);
                if(tmpSet.Count == 0)
                    return new List<string>();
                friendsSet = tmpSet;
                preSet.UnionWith(tmpSet);
                level--;
            }

            
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach(int i in friendsSet) {
                foreach(string video in watchedVideos[i]) {
                    if(!dic.ContainsKey(video))
                        dic.Add(video, 0);
                    dic[video]++;
                }
            }

            List<string> list = dic.OrderBy(x => x.Value)
                                    .ThenBy(x => x.Key)
                                    .Select(x => x.Key)
                                    .ToList();

            return list;
        }
    }
}
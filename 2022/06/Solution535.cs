using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 535
    /// title: TinyURL 的加密与解密
    /// problems: https://leetcode.cn/problems/encode-and-decode-tinyurl/
    /// date: 20220629
    /// </summary>
    public static class Solution535
    {
        public class Codec {

            private Dictionary<int, string> _map = new();
            private int _id;

            // Encodes a URL to a shortened URL
            public string encode(string longUrl) {
                _id++;
                if(!_map.ContainsKey(_id))
                    _map.Add(_id, longUrl);
                else
                    _map[_id] = longUrl;
                
                return $"http://tinyurl.com/{_id}";
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl) {
                int id = int.Parse(shortUrl.Split('/').Last());

                return _map[id];
            }
        }
    }
}
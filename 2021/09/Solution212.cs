using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 212
    /// title: 单词搜索 II
    /// problems: https://leetcode-cn.com/problems/word-search-ii/
    /// date: 20210916
    /// </summary>
    public static class Solution212
    {
        // 参考解答 字典树
        public static IList<string> FindWords(char[][] board, string[] words) {
            int[][] dirs = new int[][] {
                new int[]{1, 0},
                new int[]{-1, 0},
                new int[]{0, 1},
                new int[]{0, -1}
            };

            
            ISet<string> result = new HashSet<string>();

            void DFS(char[][] board, Trie now, int i1, int j1) {
                if (!now.children.ContainsKey(board[i1][j1])) {
                    return;
                }
                char ch = board[i1][j1];
                Trie nxt = now.children[ch];
                if (!"".Equals(nxt.word)) {
                    result.Add(nxt.word);
                    nxt.word = "";
                }

                if (nxt.children.Count > 0) {
                    board[i1][j1] = '#';
                    int[][] dirs = new int[][] {
                        new int[]{1, 0},
                        new int[]{-1, 0},
                        new int[]{0, 1},
                        new int[]{0, -1}
                    };
                    foreach (int[] dir in dirs) {
                        int i2 = i1 + dir[0], j2 = j1 + dir[1];
                        if (i2 >= 0 && i2 < board.Length && j2 >= 0 && j2 < board[0].Length) {
                            DFS(board, nxt, i2, j2);
                        }
                    }
                    board[i1][j1] = ch;
                }

                if (nxt.children.Count == 0) {
                    now.children.Remove(ch);
                }
            }

            Trie trie = new Trie();
            foreach (string word in words) {
                trie.Insert(word);
            }

            for (int i = 0; i < board.Length; ++i) {
                for (int j = 0; j < board[0].Length; ++j) {
                    DFS(board, trie, i, j);
                }
            }

            return new List<string>(result);
        }

        class Trie {
            public string word;
            public Dictionary<char, Trie> children;
            public bool isWord;

            public Trie() {
                this.word = "";
                this.children = new Dictionary<char, Trie>();
            }

            public void Insert(string word) {
                Trie cur = this;
                foreach (char c in word) {
                    if (!cur.children.ContainsKey(c)) {
                        cur.children.Add(c, new Trie());
                    }
                    cur = cur.children[c];
                }
                cur.word = word;
            }
        }
    }
}
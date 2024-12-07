using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 782
    /// title: 变为棋盘
    /// problems: https://leetcode.cn/problems/transform-to-chessboard/
    /// date: 20220823
    /// </summary>
    public static partial class Solution782
    {
        // 参考解答
        public static int MovesToChessboard(int[][] board) {
            int n = board.Length;
            int rowMask = 0, colMask = 0;

            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }

            int GetMoves(int mask, int count) {
                int ones = BitCount(mask);
                if ((n & 1) == 1) {
                    /* 如果 n 为奇数，则每一行中 1 与 0 的数目相差为 1，且满足相邻行交替 */
                    if (Math.Abs(n - 2 * ones) != 1 || Math.Abs(n - 2 * count) != 1 ) {
                        return -1;
                    }
                    if (ones == (n >> 1)) {
                        /* 以 0 为开头的最小交换次数 */
                        return n / 2 - BitCount((int)(mask & 0xAAAAAAAA));
                    } else {
                        return (n + 1) / 2 - BitCount(mask & 0x55555555);
                    }
                } else { 
                    /* 如果 n 为偶数，则每一行中 1 与 0 的数目相等，且满足相邻行交替 */
                    if (ones != (n >> 1) || count != (n >> 1)) {
                        return -1;
                    }
                    /* 找到行的最小交换次数 */
                    int count0 = n / 2 - BitCount((int)(mask & 0xAAAAAAAA));
                    int count1 = n / 2 - BitCount(mask & 0x55555555); 

                    return Math.Min(count0, count1);
                }
            }

            /* 检查棋盘的第一行与第一列 */
            for (int i = 0; i < n; i++) {
                rowMask |= (board[0][i] << i);
                colMask |= (board[i][0] << i);
            }
            int reverseRowMask = ((1 << n) - 1) ^ rowMask;
            int reverseColMask = ((1 << n) - 1) ^ colMask;
            int rowCnt = 0, colCnt = 0;
            for (int i = 0; i < n; i++) {
                int currRowMask = 0;
                int currColMask = 0;
                for (int j = 0; j < n; j++) {
                    currRowMask |= (board[i][j] << j);
                    currColMask |= (board[j][i] << j);
                }
                /* 检测每一行的状态是否合法 */
                if (currRowMask != rowMask && currRowMask != reverseRowMask) {
                    return -1;
                } else if (currRowMask == rowMask) {
                    /* 记录与第一行相同的行数 */
                    rowCnt++;
                }
                /* 检测每一列的状态是否合法 */
                if (currColMask != colMask && currColMask != reverseColMask) {
                    return -1;
                } else if (currColMask == colMask) {
                    /* 记录与第一列相同的列数 */
                    colCnt++;
                }
            }

            int rowMoves = GetMoves(rowMask, rowCnt);
            int colMoves = GetMoves(colMask, colCnt);
            
            return (rowMoves == -1 || colMoves == -1) ? -1 : (rowMoves + colMoves); 
        }   
    }
}
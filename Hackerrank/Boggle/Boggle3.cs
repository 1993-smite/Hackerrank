using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle
{
    class Boggle3
    {
        public string word;
        public char[][] board;
        private bool isWrd = false;
        public Boggle3(char[][] board, string word)
        {
            // Your code here!
            this.word = word;
            this.board = board;

            int n = board.Length;
            var currentPath = new bool[n][];

            for (int i = 0; i < n; i++)
            {
                currentPath[i] = new bool[n];
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (findWord(word, 0, board, i, j, currentPath))
                    {
                        isWrd = true;
                        return;
                    }
                }
            }
            isWrd = false;
        }

        private bool findWord(string word, int init, char[][] board, int i, int j, bool[][] currentPath)
        {
            if (init == word.Length - 1)
                return (board[i][j] == word[init]);
            if (init >= word.Length || board[i][j] != word[init])
                return false;

            currentPath[i][j] = true;
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (x >= 0 && x < board.Length &&
                            y >= 0 && y < board.Length &&
                            !currentPath[x][y] &&
                            findWord(word, init + 1, board, x, y, currentPath))
                    {
                        return true;
                    }
                }
            }
            currentPath[i][j] = false;
            return false;
        }

        public bool Check()
        {
            // Your code here too!
            return isWrd;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle
{
    class Boggle1
    {
        public string word;
        public char[][] board;
        private bool isWrd = false;
        public Boggle1(char[][] board, string word)
        {
            // Your code here!
            this.word = word;
            this.board = board;

            for (int i = 0; i < this.board.Length; i++)
            {
                for (int j = 0; j < this.board[i].Length; j++)
                {
                    if (find(i, j, board, word))
                    {
                        isWrd = true;
                        return;
                    }
                }
            }
            isWrd = false;
        }

        private bool find(int i, int j, char[][] board, string word)
        {
            if (word.Length == 1)
            {
                return board[i][j] == word[0];
            }

            bool v0 = false, v1 = false, v2 = false, v3 = false, v4 = false, v5 = false, v6 = false, v7 = false, v8 = false;
            int m = board.Length;
            int n = board[i].Length;
            string part = word.Substring(1, word.Length - 1);

            v0 = board[i][j] == word[0];

            // Search the neighbourhood
            if (i > 0) { v1 = find(i - 1, j, board, part); }
            if (i > 0 && j < n - 1) { v2 = find(i - 1, j + 1, board, part); }
            if (j < n - 1) { v3 = find(i, j + 1, board, part); }
            if (i < m - 1 && j < n - 1) { v4 = find(i + 1, j + 1, board, part); }
            if (i < m - 1) { v5 = find(i + 1, j, board, part); }
            if (i < m - 1 && j > 0) { v6 = find(i + 1, j - 1, board, part); }
            if (j > 0) { v7 = find(i, j - 1, board, part); }
            if (i > 0 && j > 0) { v8 = find(i - 1, j - 1, board, part); }


            return v0 && (v1 || v2 || v3 || v4 || v5 || v6 || v7 || v8);
        }

        public bool Check()
        {
            // Your code here too!
            return isWrd;
        }

    }
}

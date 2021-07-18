using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle
{
    class Boggle2
    {
        public string word;
        public char[][] board;
        private bool isWrd = false;
        public Boggle2(char[][] board, string word)
        {
            // Your code here!
            this.word = word;
            this.board = board;

            for (int i = 0; i < this.board.Length; i++)
            {
                for (int j = 0; j < this.board[i].Length; j++)
                {
                    if (find(i, j, 0))
                    {
                        isWrd = true;
                        return;
                    }
                }
            }
            isWrd = false;
        }

        private bool find(int i, int j, int start)
        {
            if (board[i][j] != word[start])
                return false;
            else if (start == word.Length - 1)
                return true;

            for (int k = i - 1; k <= i + 1; k++)
                for (int l = j - 1; l <= j + 1; l++)
                    if ((k != i || l != j) && 0 <= k && k < 4 && 0 <= l && l < 4 ){
                        if (find(k, l, start + 1))
                            return true;
                    }
            return false;
        }

        public bool Check()
        {
            // Your code here too!
            return isWrd;
        }

    }
}

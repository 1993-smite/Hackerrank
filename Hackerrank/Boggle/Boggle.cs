using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle
{
    public class Boggle
    {
        public string word;
        public char[,] board;
        private bool isWrd = false;

        public Boggle(char[][] board, string word)
        {
            // Your code here!
            this.word = word;
            this.board = new char[board.Length,board[0].Length];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                    this.board[i, j] = board[i][j];
            }

            findWords(this.board);
        }

        public void findWordsUtil(char[,] boggle, bool[,] visited,
                              int i, int j, string str)
        {
            // Mark current cell as visited and
            // append current character to str
            visited[i, j] = true;
            str = str + boggle[i, j];

            // If str is present in dictionary,
            // then print it
            if (isWord(str))
                isWrd = true;

            // Traverse 8 adjacent cells of boggle[i,j]
            for (int row = i - 1; row <= i + 1 && row < board.GetLength(0); row++)
                for (int col = j - 1; col <= j + 1 && col < board.GetLength(1); col++)
                    if (row >= 0 && col >= 0 && !visited[row, col])
                        findWordsUtil(boggle, visited, row, col, str);

            // Erase current character from string and 
            // mark visited of current cell as false
            str = "" + str[str.Length - 1];
            visited[i, j] = false;
        }

        // Prints all words present in dictionary.
        public void findWords(char[,] boggle)
        {
            // Mark all characters as not visited
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];

            // Initialize current string
            string str = "";

            // Consider every character and look for all words
            // starting with this character
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    findWordsUtil(boggle, visited, i, j, str);
        }

        private bool isWord(string str)
        {
            // Linearly search all words
            for (int i = 0; i < str.Length; i++)
                if (str.Equals(this.word))
                    return true;
            return false;
        }

        public bool Check()
        {
            // Your code here too!
            return isWrd;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestRelations
{
    public class Cell
    {
        public int x;
        public int y;
    }

    public class Boggle
    {
        public Dictionary<char,List<Cell>> cells = new Dictionary<char, List<Cell>>();
        public string Word;

        public Boggle(char[][] board, string word)
        {
            // Your code here!
            for(int x = 0; x < board.Length; x++)
            {
                for(int y = 0; y < board[x].Length; y++)
                {
                    if (cells.ContainsKey(board[x][y])){
                        cells[board[x][y]].Add(new Cell() { x = x, y = y });
                    }
                    else
                    {
                        cells.Add(board[x][y], new List<Cell>() { new Cell() { x = x, y = y } });
                    }
                }
            }

            Word = word;
        }

        public bool Check()
        {
            // Your code here too!
            foreach(var s in Word)
            {
                var list = cells[s];
                foreach(var it in list)
                {

                }
            }


            return false;
        }
    }
}

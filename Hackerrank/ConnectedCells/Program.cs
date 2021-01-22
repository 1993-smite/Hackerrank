using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedCells
{
    public class Cell
    {
        public List<Tuple<int, int>> Cells = new List<Tuple<int, int>>();
        public int CellsCount => Cells.Count;

        public bool FindCell(int i, int j)
        {
            return Cells.Exists(x => x.Item1 == i && x.Item2 == j);
        }

        public void AddCell(int i, int j)
        {
            Cells.Add(new Tuple<int, int>(i, j));
        }

        public void AddCells(Cell cell)
        {
            Cells.AddRange(cell.Cells);
        }
    }

    class Program
    {
        
        // Complete the connectedCell function below.
        static int connectedCell1(int[][] matrix)
        {
            int count = 0;

            List<Cell> cells = new List<Cell>();

            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j=0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                        continue;

                    int lastX = i == 0 ? 0 : matrix[i-1][j];
                    int lastY = j == 0 ? 0 : matrix[i][j-1];
                    int lastXY = i == 0 || j == 0 ? 0 : matrix[i - 1][j - 1];
                    int lastYX = i == 0 || j == matrix[i].Length - 1 ? 0 : matrix[i - 1][j + 1];

                    int x = i, y = j;

                    if (lastXY == 1)
                    {
                        x = i - 1;
                        y = j - 1;
                    }
                    else if (lastYX == 1)
                    {
                        x = i - 1;
                        y = j + 1;
                    }
                    else if (lastX == 1)
                    {
                        x = i - 1;
                    }
                    else if (lastY == 1)
                    {
                        y = j - 1;
                    }

                    var cellArr = cells.Where(it => it.FindCell(x,y)).ToList();
                    var cell = new Cell();
                    if (cellArr.Count == 0)
                    {
                        cells.Add(cell);
                    }
                    else
                    {
                        cell = cellArr.First();
                        for (int k = 1; k < cellArr.Count(); k++)
                        {
                            cell.AddCells(cellArr[k]);
                        }
                    }
                    cell.AddCell(i, j);
                }
            }

            return cells.Max(x=>x.CellsCount);
        }

        static int Fill(int[][] img, int[][] labels, int x, int y, int L, int cnt)
        {
            if ((labels[y][x] == 0) && (img[y][x] == 1))
            {
                labels[y][x] = L; cnt++;
                // |
                if (y > 0)
                    cnt += Fill(img, labels, x, y - 1, L, 0);
                if (y < img.Length-1)
                    cnt += Fill(img, labels, x, y + 1, L, 0);
                // -
                if (x > 0)
                    cnt += Fill(img, labels, x - 1, y, L, 0);
                if (x < img[y].Length - 1)
                    cnt += Fill(img, labels, x + 1, y, L, 0);
                // \
                if (x > 0 && y > 0)
                    cnt += Fill(img, labels, x - 1, y - 1, L, 0);
                if (x < img[y].Length - 1 && y < img.Length - 1)
                    cnt += Fill(img, labels, x + 1, y + 1, L, 0);
                // /
                if (x > 0 && y < img.Length - 1)
                    cnt += Fill(img, labels, x - 1, y + 1, L, 0);
                if (x < img[y].Length - 1 && y > 0)
                    cnt += Fill(img, labels, x + 1, y - 1, L, 0);
            }
            return cnt;
        }

        // Complete the connectedCell function below.
        static int connectedCell(int[][] matrix, int[][] labels)
        {
            int L = 1, count = 0, maxCount = 0;
            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    count = Fill(matrix, labels, x, y, L++, 0);
                    if (count > maxCount)
                        maxCount = count;
                }
            }      
            return maxCount;
        }

        static void Main(string[] args)
        {
            int[,] ff = { 
                { 0, 1, 0, 0, 0, 0, 1, 1, 0 }, 
                { 1, 1, 0, 0, 1, 0, 0, 0, 1 }, 
                { 0, 0, 0, 0, 1, 0, 1, 0, 0 }, 
                { 0, 1, 1, 1, 0, 1, 0, 1, 1 },
                { 0, 1, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 1, 0, 1, 1, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 1, 1, 0, 1, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 0, 0 }
            };

            int count = ff.GetLength(0);
            int[][] f = new int[count][];
            int[][] f1 = new int[count][];

            for (int i = 0; i < count; i++)
            {
                f[i] = new int[ff.GetLength(1)];
                f1[i] = new int[ff.GetLength(1)];
                for (int j=0;j< ff.GetLength(1); j++)
                {
                    f[i][j] = ff[i, j];
                }
            }

            var res = connectedCell(f, f1);

            int result = 0;

            for (int i = 0; i < f1.Length; i++)
            {
                for (int j = 0; j < f1[i].Length; j++)
                {
                    Console.Write(" {0,2}", f1[i][j]);

                    if (f1[i][j] == 13)
                        result++;
                }
                Console.Write("\n");
                //Console.WriteLine(string.Join(" ", f1[i]));
            }
            Console.WriteLine(res);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
